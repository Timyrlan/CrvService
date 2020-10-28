using System.Collections.Concurrent;
using CrvService.Shared.Contracts.Entities;

namespace CrvService.Shared.Logic.ClientSide.Server
{
    public class PlayerRepositoryClientSide : IPlayerRepository
    {
        private readonly ConcurrentDictionary<string, IPlayer> Players = new ConcurrentDictionary<string, IPlayer>();

        public IPlayer GetPlayer(string guid)
        {
            if (Players.TryGetValue(guid, out var result)) return result;

            return null;
        }

        public void Add(IPlayer player)
        {
            Players.AddOrUpdate(player.Guid, s => player, (s, player1) => player);
        }
    }
}