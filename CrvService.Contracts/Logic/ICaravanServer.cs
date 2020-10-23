using CrvService.Shared.Contracts.Dto;
using CrvService.Shared.Contracts.Entities;

namespace CrvService.Shared.Logic
{
    public interface ICaravanServer
    {
        ProcessWorldDto ProcessWorld(string worldGuid, string clientGuid);
        void LoadWorld(IWorld world);
    }
}