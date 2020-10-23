using CrvService.Shared.Contracts.Dto.Base;

namespace CrvService.Shared.Contracts.Dto
{
    public class PlayerDto : DtoBase
    {
        public string[] VisibleCities { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
    }
}