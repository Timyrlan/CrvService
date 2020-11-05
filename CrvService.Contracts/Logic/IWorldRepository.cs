using System.Threading.Tasks;
using CrvService.Shared.Contracts.Entities;

namespace CrvService.Shared.Logic
{
    public interface IWorldRepository
    {
        IWorld GetWorld(string guid);

        Task<IWorld> GetWorldAsync(string guid);

        void Add(IWorld world);
    }
}