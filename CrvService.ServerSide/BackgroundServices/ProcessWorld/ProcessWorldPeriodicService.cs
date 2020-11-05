using System.Linq;
using System.Threading.Tasks;
using CrvService.Common;
using CrvService.Common.Options;
using CrvService.Data;
using CrvService.Data.Entities;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CrvService.ServerSide.BackgroundServices.ProcessWorld
{
    public class ProcessWorldPeriodicService : PeriodicServiceBase<ProcessWorldPeriodicServiceOptions>
    {
        public ProcessWorldPeriodicService(
            IOptions<ProcessWorldPeriodicServiceOptions> options,
            ILogger<ProcessWorldPeriodicService> logger,
            IOptions<Logging.Logging> logging,
            IPeriodicServiceRepository periodicServiceRepository,
            ICrvServiceContextFactory crvServiceContextFactory,
            IProcessorsProvider processorsProvider) : base(options, logger, logging, periodicServiceRepository)
        {
            CrvServiceContextFactory = crvServiceContextFactory;
            ProcessorsProvider = processorsProvider;
        }

        private ICrvServiceContextFactory CrvServiceContextFactory { get; }
        private IProcessorsProvider ProcessorsProvider { get; }


        protected override async Task DoWork(ExecutingContext ec)
        {
            while (!ec.CancellationToken.IsCancellationRequested)
                using (var context = CrvServiceContextFactory.GetContext())
                {
                    var commands = await context.ClientCommands.Where(c => !c.Processed).Take(1000).ToArrayAsync();

                    if (!commands.Any())
                    {
                        await DeleteExecutedClientCommands(context);
                        return;
                    }


                    var worldGuids = commands.Select(c => c.WorldGuid).Distinct().ToArray();
                    foreach (var worldGuid in worldGuids) await ProcessWorld(worldGuid, commands.Where(c => c.WorldGuid == worldGuid).OrderBy(c => c.Id).ToArray(), context);


                    await context.SaveAsync();
                    await DeleteExecutedClientCommands(context);
                }
        }

        private async Task DeleteExecutedClientCommands(ICrvServiceContext context)
        {
            if (Options.DeleteExecutedClientCommands) await context.DeleteExecutedClientCommands();
        }

        private async Task ProcessWorld(string worldGuid, ClientCommandEntity[] commands, ICrvServiceContext context)
        {
            var world = await context.Worlds.FirstOrDefaultAsync(c => c.Guid == worldGuid);
            IPlayer player = null;
            foreach (var command in commands)
            {
                if (player == null || player.Guid != command.PlayerGuid) player = await context.Players.FirstOrDefaultAsync(c => c.Guid == command.PlayerGuid);

                ProcessorsProvider.ProcessClientCommand(command, world, player);
            }

            ProcessorsProvider.Process(world);
        }
    }

    public class ProcessWorldPeriodicServiceOptions : PeriodicServiceOptions
    {
        public override string ServiceName => nameof(ProcessWorldPeriodicService);
        public bool DeleteExecutedClientCommands { get; set; }

        public override int PeriodMilliseconds { get; set; } = 100;
    }
}