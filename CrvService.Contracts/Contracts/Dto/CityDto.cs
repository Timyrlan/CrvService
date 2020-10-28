using CrvService.Shared.Contracts.Dto.Base;
using CrvService.Shared.Contracts.Dto.Buildings;

namespace CrvService.Shared.Contracts.Dto
{
    public class CityDto : DtoBase
    {
        public BuildingDto[] Buildings = { };
        public string Name;
        public float Size;

        public bool Visible;
        public float X;
        public float Y;
    }
}