using CrvService.Shared.Contracts.Dto.Base;

namespace CrvService.Shared.Contracts.Dto
{
    public class ProcessWorldResponse : ResponseBase
    {
        public PlayerDto Player;
        public WorldDto World;
    }
}