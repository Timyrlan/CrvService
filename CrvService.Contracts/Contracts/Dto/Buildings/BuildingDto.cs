using CrvService.Shared.Contracts.Dto.Base;
using CrvService.Shared.Contracts.Dto.Cargos;

namespace CrvService.Shared.Contracts.Dto.Buildings
{
    public class BuildingDto : DtoBase
    {
        public CargoDto[] Cargos = { };
    }
}