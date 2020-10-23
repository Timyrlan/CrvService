using CrvService.Shared.Contracts.Dto.Base;
using CrvService.Shared.Contracts.Dto.Buildings;

namespace CrvService.Shared.Contracts.Dto
{
    public class CityDto : DtoBase
    {
        public float Size { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public string Name { get; set; }

        public bool Visible { get; set; }

        public BuildingDto[] Buildings { get; set; } = { };
    }
}