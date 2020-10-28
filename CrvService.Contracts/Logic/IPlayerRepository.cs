using CrvService.Shared.Contracts.Entities;

namespace CrvService.Shared.Logic
{
    public interface IPlayerRepository
    {
        IPlayer GetPlayer(string guid);

        void Add(IPlayer world);
    }
}