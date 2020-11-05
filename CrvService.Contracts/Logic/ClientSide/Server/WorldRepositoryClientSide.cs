using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using CrvService.Shared.Contracts.Entities;

namespace CrvService.Shared.Logic.ClientSide.Server
{
    public class WorldRepositoryClientSide : IWorldRepository
    {
        private readonly ConcurrentDictionary<string, IWorld> Worlds = new ConcurrentDictionary<string, IWorld>();

        public IWorld GetWorld(string guid)
        {
            if (Worlds.TryGetValue(guid, out var result)) return result;

            return null;
        }

        public Task<IWorld> GetWorldAsync(string guid)
        {
            throw new NotImplementedException();
        }

        public void Add(IWorld world)
        {
            Worlds.AddOrUpdate(world.Guid, s => world, (s, world1) => world);
        }
    }
}