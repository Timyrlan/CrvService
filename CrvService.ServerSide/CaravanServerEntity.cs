using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrvService.Data;
using CrvService.Data.Entities;
using CrvService.Data.Entities.Commands.ClientCommands;
using CrvService.Data.Entities.Commands.ClientCommands.Base;
using CrvService.Shared.Contracts.Dto.Base;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Logic;
using Microsoft.EntityFrameworkCore;

namespace CrvService.ServerSide
{
    public class CaravanServerEntity : ICaravanServer
    {
        public CaravanServerEntity(ICrvServiceContextFactory contextFactory, INewInstanceFactory newInstanceFactory)
        {
            ContextFactory = contextFactory;
            NewInstanceFactory = newInstanceFactory;
        }

        private ICrvServiceContextFactory ContextFactory { get; }
        private INewInstanceFactory NewInstanceFactory { get; }

        public IProcessWorldResponse GetNewWorld(IGetNewWorldRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IProcessWorldResponse> GetNewWorldAsync(IGetNewWorldRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (string.IsNullOrWhiteSpace(request.UserGuid)) throw new Exception("UserGuid is empty");

            using var context = ContextFactory.GetContext();
            using var instances = new Instances(context, NewInstanceFactory);

            var generated = instances.NewWorldGenerator.GenerateWorld(request.UserGuid);

            await context.SaveAsync();

            return new ProcessWorldResponseEntity {Player = generated.Item2, World = generated.Item1};
        }


        public IProcessWorldResponse ProcessWorld(IProcessWorldRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IProcessWorldResponse> ProcessWorldAsync(IProcessWorldRequest request)
        {
            if (request == null) throw new ProcessBadRequestException(nameof(request));
            if (request.Player == null) throw new ProcessBadRequestException("Player is null");

            var clientCommands = new List<ClientCommandEntity>();

            DateTime worldVersion;
            using (var context = ContextFactory.GetContext())
            {
                var player = await context.Players.FirstOrDefaultAsync(c => c.Guid == request.Player.Guid);

                if (player == null) throw new ProcessBadRequestException($"Player with guid='{request.Player.Guid}' not found");

                var world = await context.Worlds.FirstOrDefaultAsync(c => c.Guid == request.WorldGuid);
                if (world == null) throw new ProcessBadRequestException($"World with guid='{request.WorldGuid}' not found");

                worldVersion = world.WorldDate;

                if (!request.ClientCommands.Any())
                    clientCommands.Add(ClientCommandMapper.Map(new PingEntity(), world, player));
                else
                    clientCommands.AddRange(request.ClientCommands.Select(c => ClientCommandMapper.Map(c, world, player)));

                context.ClientCommands.AddRange(clientCommands);

                player.X = request.Player.X;
                player.Y = request.Player.Y;
                player.MoveToX = request.Player.MoveToX;
                player.MoveToY = request.Player.MoveToY;

                var processedCommands = await context.ServerCommands.Where(c => !c.Processed && c.Id <= request.LastServerCommandProcessed).ToArrayAsync();
                foreach (var processedCommand in processedCommands)
                {
                    processedCommand.Processed = true;
                    processedCommand.ProcessDateTime = DateTime.UtcNow;
                }

                await context.SaveAsync();
            }

            for (var i = 0; i < 5; i++)
            {
                await Task.Delay(200);

                using (var context = ContextFactory.GetContext())
                {
                    var worldCurrentVersion = await context.Worlds.Where(c => c.Guid == request.WorldGuid).Select(c => c.WorldDate).FirstOrDefaultAsync();

                    if (worldCurrentVersion > worldVersion) break;
                }
            }

            using (var context = ContextFactory.GetContext())
            {
                var result = new ProcessWorldResponseEntity
                {
                    Player = await context.Players.FirstOrDefaultAsync(c => c.Guid == request.Player.Guid),
                    World = await GetFullWorld(request.WorldGuid, context)
                };

                result.Player.Commands.LoadCollection(await context.ServerCommands.Where(c => c.PlayerGuid == result.Player.Guid).ToArrayAsync());

                return result;
            }
        }

        public void LoadWorld(IWorld world)
        {
            throw new NotImplementedException();
        }

        private async Task<WorldEntity> GetFullWorld(string worldGuid, ICrvServiceContext context)
        {
            return await context.Worlds
                .Include(c => c.CityCollection).ThenInclude(c => c.BuildingCollection).ThenInclude(c => c.CargoCollection)
                .Include(c => c.PlayerCollection)
                .FirstOrDefaultAsync(c => c.Guid == worldGuid);
        }
    }
}