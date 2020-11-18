using System;
using CrvService.Data;
using CrvService.Shared.Logic;
using CrvService.Shared.Logic.ClientSide;

namespace CrvService.ServerSide
{
    public class Instances : IDisposable
    {
        public Instances(ICrvServiceContext context, INewInstanceFactory newInstanceFactory)
        {
            WorldRepository = new WorldRepositoryEntity(context);
            ProcessorsProvider = new ProcessorsProvider(newInstanceFactory);
            NewWorldGenerator = new NewWorldGenerator(newInstanceFactory, WorldRepository);
        }

        public IWorldRepository WorldRepository { get; }


        public IProcessorsProvider ProcessorsProvider { get; }

        public INewWorldGenerator NewWorldGenerator { get; }


        public void Dispose()
        {
            //здесь диспозить зиспозиумые объекты
        }
    }
}