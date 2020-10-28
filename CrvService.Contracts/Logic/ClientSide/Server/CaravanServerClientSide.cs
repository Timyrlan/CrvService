using System;
using System.Linq;
using CrvService.Shared.Contracts.Entities;

// ReSharper disable UseObjectOrCollectionInitializer

namespace CrvService.Shared.Logic.ClientSide.Server
{
    public class CaravanServerClientSide : ICaravanServer
    {
        public CaravanServerClientSide(IProcessorsProvider processorsProvider, INewInstanceFactory newInstanceFactory, INewWorldGenerator newWorldGenerator, IPlayerRepository playerRepository, IWorldRepository worldRepository)
        {
            ProcessorsProvider = processorsProvider;
            NewInstanceFactory = newInstanceFactory;
            NewWorldGenerator = newWorldGenerator;
            PlayerRepository = playerRepository;
            WorldRepository = worldRepository;
        }

        private IProcessorsProvider ProcessorsProvider { get; }
        private INewInstanceFactory NewInstanceFactory { get; }
        private INewWorldGenerator NewWorldGenerator { get; }
        private IPlayerRepository PlayerRepository { get; }
        private IWorldRepository WorldRepository { get; }


        public IProcessWorldResponse GetNewWorld(IGetNewWorldRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var generated = NewWorldGenerator.GenerateWorld(request.Player);


            var result = new ProcessWorldResponseClientSideEntity();
            result.Player = generated.Item2;
            result.World = generated.Item1;

            return result;
        }

        public IProcessWorldResponse ProcessWorld(IProcessWorldRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Player == null) throw new Exception("Player is null");

            var player = PlayerRepository.GetPlayer(request.Player.Guid);
            if (player == null) throw new Exception($"Player with guid='{request.Player.Guid}' not found");

            var world = WorldRepository.GetWorld(request.WorldGuid);
            if (world == null) throw new Exception($"World with guid='{request.WorldGuid}' not found");

            player.X = request.Player.X;
            player.Y = request.Player.Y;
            if (request.ClientCommands != null && request.ClientCommands.Any())
                foreach (var clientCommand in request.ClientCommands)
                    ProcessorsProvider.ProcessClientCommand(clientCommand, world, player);

            ProcessorsProvider.Process(world);

            foreach (var worldCity in world.Cities.Collection)
                if (!player.VisibleCities.Contains(worldCity.Guid))
                    if (CoordinateHelper.GetDistance(player.X, player.Y, worldCity.X, worldCity.Y) < worldCity.Size * 2)
                        player.VisibleCities = player.VisibleCities.Union(new[] {worldCity.Guid}).ToArray();

            ProcessorsProvider.Process(player);


            var result = new ProcessWorldResponseClientSideEntity();
            result.Player = player;
            result.World = world;

            return result;
        }

        public void LoadWorld(IWorld world)
        {
            WorldRepository.Add(world);
        }
    }
}