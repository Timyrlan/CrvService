using CrvService.Shared.Contracts.Dto.Base;

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
    }
}