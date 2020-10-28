using CrvService.Shared.Contracts.Entities;

namespace CrvService.Shared.Logic
{
    public interface ICaravanServer
    {
        IProcessWorldResponse GetNewWorld(IGetNewWorldRequest request);
        IProcessWorldResponse ProcessWorld(IProcessWorldRequest request);
        void LoadWorld(IWorld world);
    }
}