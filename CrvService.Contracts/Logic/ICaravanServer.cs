using CrvService.Shared.Contracts.Dto;
using CrvService.Shared.Contracts.Entities;

namespace CrvService.Shared.Logic
{
    public interface ICaravanServer
    {
        IProcessWorldResponse ProcessWorld(IProcessWorldRequest request);
        void LoadWorld(IWorld world);
    }
}