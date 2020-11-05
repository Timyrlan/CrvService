using System.Linq;
using CrvService.Data;
using CrvService.Data.Entities;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Logic;

namespace CrvService.ServerSide
{
    public class PlayerEntityRepository : IPlayerRepository
    {
        public PlayerEntityRepository(ICrvServiceContext context)
        {
            Context = context;
        }

        private ICrvServiceContext Context { get; }

        public IPlayer GetPlayer(string guid)
        {
            return Context.Players.FirstOrDefault(c => c.Guid == guid);
        }

        public void Add(IPlayer player)
        {
            var casted = H.Cast<PlayerEntity>(player);
            Context.Players.Add(casted);
        }
    }
}