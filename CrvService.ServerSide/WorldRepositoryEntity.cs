using System;
using System.Threading.Tasks;
using CrvService.Data;
using CrvService.Data.Entities;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Logic;
using Microsoft.EntityFrameworkCore;

namespace CrvService.ServerSide
{
    public class WorldRepositoryEntity : IWorldRepository
    {
        public WorldRepositoryEntity(ICrvServiceContext context)
        {
            Context = context;
        }

        private ICrvServiceContext Context { get; }

        public IWorld GetWorld(string guid)
        {
            throw new NotImplementedException();
        }

        public async Task<IWorld> GetWorldAsync(string guid)
        {
            return await Context.Worlds.Include(c => c.Players).FirstOrDefaultAsync(c => c.Guid == guid);
        }

        public void Add(IWorld world)
        {
            Context.Worlds.Add(H.Cast<WorldEntity>(world));
        }
    }
}