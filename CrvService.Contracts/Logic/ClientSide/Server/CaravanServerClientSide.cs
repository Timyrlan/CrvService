using System;
using System.Linq;
using CrvService.Shared.Contracts.Entities;

// ReSharper disable UseObjectOrCollectionInitializer

namespace CrvService.Shared.Logic.ClientSide.Server
{
    public class CaravanServerClientSide : ICaravanServer
    {
        public CaravanServerClientSide(IProcessorsProvider processorsProvider, INewInstanceFactory newInstanceFactory, INewWorldGenerator newWorldGenerator)
        {
            ProcessorsProvider = processorsProvider;
            NewInstanceFactory = newInstanceFactory;
            NewWorldGenerator = newWorldGenerator;
        }

        private IProcessorsProvider ProcessorsProvider { get; }
        private INewInstanceFactory NewInstanceFactory { get; }
        private INewWorldGenerator NewWorldGenerator { get; }
        private IWorld World { get; set; }

        private IPlayer Player { get; set; }

        public IProcessWorldResponse ProcessWorld(IProcessWorldRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (World?.Guid != request.WorldGuid || string.IsNullOrWhiteSpace(request.Player?.Guid) || request.Player.Guid != Player?.Guid)
            {
                var generated = NewWorldGenerator.GenerateWorld(null);
                World = generated.Item1;
                Player = generated.Item2;
            }
            else
            {
                if (Player == null) throw new Exception("Player is null");
                Player.X = request.Player.X;
                Player.Y = request.Player.Y;
                if (request.ClientCommands != null && request.ClientCommands.Any())
                    foreach (var clientCommand in request.ClientCommands)
                        ProcessorsProvider.ProcessClientCommand(clientCommand, World, Player);

                ProcessorsProvider.Process(World);
                ProcessorsProvider.Process(Player);
            }


            var result = new ProcessWorldResponseClientSideEntity();
            result.Player = Player;
            result.World = World;

            return result;
        }

        public void LoadWorld(IWorld world)
        {
            World = world;
        }
    }
}