using CrvService.Shared.Contracts.Entities;

namespace CrvService.Shared.Logic
{
    public interface IWorldRepository
    {
        IWorld GetWorld(string guid);

        void Add(IWorld world);
    }
}