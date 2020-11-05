using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CrvService.Data
{
    public class CrvServiceContextFactory : ICrvServiceContextFactory
    {
        private readonly object _initializeLockObj = new object();
        private bool _initialized;

        public CrvServiceContextFactory(
            ILogger<CrvServiceContextFactory> logger,
            ILogger<CrvServiceContext> loggerCrvServiceContext,
            IOptions<Logging.Logging> logging,
            IOptions<CrvServiceContextOptions> crvServiceContextOptions
        )
        {
            Logger = logger;
            Logging = logging;
            CrvServiceContextOptions = crvServiceContextOptions.Value;
            LoggerCrvServiceContext = loggerCrvServiceContext;
        }

        private ILogger<CrvServiceContextFactory> Logger { get; }
        private IOptions<Logging.Logging> Logging { get; }
        private CrvServiceContextOptions CrvServiceContextOptions { get; }
        private ILogger<CrvServiceContext> LoggerCrvServiceContext { get; }

        public ICrvServiceContext GetContext(int? timeoutSeconds = null)
        {
            if (!_initialized)
                lock (_initializeLockObj)
                {
                    if (!_initialized)
                    {
                        var context = new CrvServiceContext(CrvServiceContextOptions.ConnectionString, LoggerCrvServiceContext, Logging);
                        context.Migrate();
                        _initialized = true;
                        return context;
                    }

                    return new CrvServiceContext(CrvServiceContextOptions.ConnectionString, LoggerCrvServiceContext, Logging);
                }

            return new CrvServiceContext(CrvServiceContextOptions.ConnectionString, LoggerCrvServiceContext, Logging);
        }
    }
}