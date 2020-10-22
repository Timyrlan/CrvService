using CrvService.Shared.Contracts.Dto;
using CrvService.Shared.Contracts.Entities;

// ReSharper disable UseObjectOrCollectionInitializer

namespace CrvService.Shared.Logic.ClientSide.Server
{
    public class CaravanServerClientSide : ICaravanServer
    {
        public CaravanServerClientSide(IProcessorsProvider processorsProvider, INewInstanceFactory newInstanceFactory)
        {
            ProcessorsProvider = processorsProvider;
            NewInstanceFactory = newInstanceFactory;
        }

        private IProcessorsProvider ProcessorsProvider { get; }
        private INewInstanceFactory NewInstanceFactory { get; }
        private IWorld World { get; set; }

        public ProcessWorldDto ProcessWorld(string worldGuid, string clientGuid)
        {
            if (World?.Guid != worldGuid) World = GenerateNewWorld();

            ProcessorsProvider.Process(World);

            var result = new ProcessWorldDto();
            result.World = ToDtoMapper.Map(World);
            return result;
        }

        public void LoadWorld(IWorld world)
        {
            World = world;
        }


        private IWorld GenerateNewWorld()
        {
            var result = NewInstanceFactory.GetNewInstance<IWorld>("World");

            return result;
        }
    }
}