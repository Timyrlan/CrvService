using System;
using System.Threading;
using System.Threading.Tasks;
using CrvService.Common.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CrvService.Common
{
    public abstract class PeriodicServiceBase<TOptions> : BackgroundService where TOptions : PeriodicServiceOptions, new()
    {
        protected PeriodicServiceBase(IOptions<TOptions> options, ILogger logger, IOptions<Logging.Logging> logging, IPeriodicServiceRepository periodicServiceRepository)
        {
            Logger = logger;
            Logging = logging.Value;
            Options = options.Value;
            PeriodicServiceRepository = periodicServiceRepository;
        }

        protected PeriodicServiceBase(TOptions options, ILogger logger, IOptions<Logging.Logging> logging, IPeriodicServiceRepository periodicServiceRepository)
        {
            Logger = logger;
            Logging = logging.Value;
            Options = options;
            PeriodicServiceRepository = periodicServiceRepository;
        }

        protected TOptions Options { get; }

        protected ILogger Logger { get; }
        private IPeriodicServiceRepository PeriodicServiceRepository { get; }

        protected Logging.Logging Logging { get; }
        protected long Interation { get; set; }

        private CancellationTokenSource Cts { get; set; }

        private bool IsStillProcessing { get; set; }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return DoWork(stoppingToken);
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            Task.Factory.StartNew(async () => await DoWork(Cts.Token), Cts.Token);
            return Task.CompletedTask;
        }

        private async Task DoWork(CancellationToken cancellationToken)
        {
            try
            {
                if (IsStillProcessing)
                    throw new Exception("still processing");

                IsStillProcessing = true;

                while (!cancellationToken.IsCancellationRequested)
                {
                    PeriodicServiceRepository.Update(Options, Interation);
                    if (!Options.Enabled)
                    {
                        Logger.LogInformation($"Service {Options.ServiceName} disabled");
                        return;
                    }

                    var ec = new ExecutingContext(cancellationToken) {EventId = new EventId(0, $"{Options.ServiceName}_{++Interation}")};

                    if (Logging.LogLevel.Gg <= LogLevel.Debug) Logger.LogDebug(ec.EventId, $"processing {Options.ServiceName} iteration {Interation} at {ec.Sw.ElapsedMilliseconds}ms");

                    try
                    {
                        await DoWork(ec);
                        PeriodicServiceRepository.UpdateRun(Options, Interation, ec.Sw.ElapsedMilliseconds, null);
                    }
                    catch (Exception e)
                    {
                        Logger.LogError(ec.EventId, e, $"Error processing {Options.ServiceName} at {ec.Sw.ElapsedMilliseconds}ms");
                        PeriodicServiceRepository.UpdateRun(Options, Interation, ec.Sw.ElapsedMilliseconds, e.ToString());
                    }

                    if (Logging.LogLevel.Gg <= LogLevel.Debug) Logger.LogDebug(ec.EventId, $"finish processing {Options.ServiceName} iteration {++Interation} at {ec.Sw.ElapsedMilliseconds}ms");

                    Task.Delay(Options.PeriodMilliseconds, cancellationToken).Wait(cancellationToken);
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"Error {Options.ServiceName} iteration {Interation}. Stop worker");
            }


            IsStillProcessing = false;
        }

        protected abstract Task DoWork(ExecutingContext ec);
    }
}