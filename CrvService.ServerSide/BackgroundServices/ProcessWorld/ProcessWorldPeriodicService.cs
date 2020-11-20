using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrvService.Common;
using CrvService.Common.Options;
using CrvService.Data;
using CrvService.Data.Entities;
using CrvService.Data.Entities.Commands.ClientCommands.Base;
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

                    if (commands.Any())
                    {
                        var worldGuids = commands.Select(c => c.WorldGuid).Distinct().ToArray();
                        foreach (var worldGuid in worldGuids) await ProcessWorld(worldGuid, commands.Where(c => c.WorldGuid == worldGuid).OrderBy(c => c.Id).ToArray(), context);


                        await context.SaveAsync();
                    }

                    await DeleteExecutedClientCommands(context);
                }
        }

        private async Task DeleteExecutedClientCommands(ICrvServiceContext context)
        {
            if (Options.DeleteExecutedClientCommands) await context.DeleteExecutedClientCommands();
        }

        private async Task ProcessWorld(string worldGuid, ClientCommandEntity[] commands, ICrvServiceContext context)
        {
            var world = await GetFullWorld(worldGuid, context);
            IPlayer player = null;
            var processedPlayers = new List<string>();
            foreach (var command in commands)
            {
                if (player == null || !processedPlayers.Contains(player.Guid))
                {

                    player = world.PlayerCollection.FirstOrDefault(c => c.Guid == command.PlayerGuid);

                    if (player!= null)
                    {
                        ProcessorsProvider.Process(player);
                        processedPlayers.Add(player.Guid);
                    }
                }

                ProcessorsProvider.ProcessClientCommand(command, world, player);
            }


            ProcessorsProvider.Process(world);
        }

        private async Task<WorldEntity> GetFullWorld(string worldGuid, ICrvServiceContext context)
        {
            return await context.Worlds
                .Include(c => c.CityCollection).ThenInclude(c => c.BuildingCollection).ThenInclude(c => c.CargoCollection)
                .Include(c => c.PlayerCollection)
                .FirstOrDefaultAsync(c => c.Guid == worldGuid);
        }
    }


    public class ProcessWorldPeriodicServiceOptions : PeriodicServiceOptions
    {
        public override string ServiceName => nameof(ProcessWorldPeriodicService);
        public bool DeleteExecutedClientCommands { get; set; }

        public override int PeriodMilliseconds { get; set; } = 100;
    }
}