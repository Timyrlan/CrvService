using CrvService.Shared.Contracts.Dto;
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

        public ProcessWorldDto ProcessWorld(string worldGuid, string clientGuid)
        {
            if (World?.Guid != worldGuid)
            {
                var generated = NewWorldGenerator.GenerateWorld(null);
                World = generated.Item1;
                Player = generated.Item2;
            }
            else
            {
                ProcessorsProvider.Process(World);
            }

            var result = new ProcessWorldDto();
            result.Player = ToDtoMapper.Map(Player);
            result.World = ToDtoMapper.Map(World, Player.VisibleCities);
            
            return result;
        }

        public void LoadWorld(IWorld world)
        {
            World = world;
        }
    }
}