﻿using System;
using System.Linq;
using System.Threading.Tasks;
using CrvService.Shared.Contracts.Entities;

// ReSharper disable UseObjectOrCollectionInitializer

namespace CrvService.Shared.Logic.ClientSide.Server
{
    public class CaravanServerClientSide : ICaravanServer
    {
        public CaravanServerClientSide(IProcessorsProvider processorsProvider, INewInstanceFactory newInstanceFactory, INewWorldGenerator newWorldGenerator, IWorldRepository worldRepository)
        {
            ProcessorsProvider = processorsProvider;
            NewInstanceFactory = newInstanceFactory;
            NewWorldGenerator = newWorldGenerator;

            WorldRepository = worldRepository;
        }

        private IProcessorsProvider ProcessorsProvider { get; }
        private INewInstanceFactory NewInstanceFactory { get; }
        private INewWorldGenerator NewWorldGenerator { get; }

        private IWorldRepository WorldRepository { get; }


        public IProcessWorldResponse GetNewWorld(IGetNewWorldRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (string.IsNullOrWhiteSpace(request.UserGuid)) throw new Exception("UserGuid is empty");

            var generated = NewWorldGenerator.GenerateWorld(request.UserGuid);


            var result = new ProcessWorldResponseClientSideEntity();
            result.Player = generated.Item2;
            result.World = generated.Item1;

            return result;
        }

        public Task<IProcessWorldResponse> GetNewWorldAsync(IGetNewWorldRequest request)
        {
            return Task.FromResult(GetNewWorld(request));
        }

        public IProcessWorldResponse ProcessWorld(IProcessWorldRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Player == null) throw new Exception("Player is null");

            var world = WorldRepository.GetWorld(request.WorldGuid);
            if (world == null) throw new Exception($"World with guid='{request.WorldGuid}' not found");

            var player = world.Players.Collection.FirstOrDefault(c => c.Guid == request.Player.Guid);
            if (player == null) throw new Exception($"Player with guid='{request.Player.Guid}' not found");

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

        public Task<IProcessWorldResponse> ProcessWorldAsync(IProcessWorldRequest request)
        {
            return Task.FromResult(ProcessWorld(request));
        }

        public void LoadWorld(IWorld world)
        {
            WorldRepository.Add(world);
        }
    }
}