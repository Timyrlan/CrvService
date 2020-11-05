using System.Threading.Tasks;
using CrvService.Shared.Contracts.Entities;

namespace CrvService.Shared.Logic
{
    public interface ICaravanServer
    {
        IProcessWorldResponse GetNewWorld(IGetNewWorldRequest request);
        Task<IProcessWorldResponse> GetNewWorldAsync(IGetNewWorldRequest request);
        IProcessWorldResponse ProcessWorld(IProcessWorldRequest request);
        Task<IProcessWorldResponse> ProcessWorldAsync(IProcessWorldRequest request);
        void LoadWorld(IWorld world);
    }
}