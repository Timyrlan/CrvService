using CrvService.Shared.Contracts.Dto.Base;
using CrvService.Shared.Contracts.Dto.Commands.ServerCommands.Base;

namespace CrvService.Shared.Contracts.Dto
{
    public class PlayerDto : DtoBase
    {
        public bool IsMoving;
        public float MoveToX;
        public float MoveToY;
        public string[] VisibleCities = { };
        public float X;
        public float Y;
        public ServerCommandDto[] ServerCommands { get; set; }
    }
}