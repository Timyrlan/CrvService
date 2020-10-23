using CrvService.Shared.Contracts.Dto.Base;
using CrvService.Shared.Contracts.Dto.Cargos;

namespace CrvService.Shared.Contracts.Dto
{
    public class BraminDto : DtoBase
    {
        public CargoDto[] Cargos { get; set; } = { };
        public long Age { get; set; }
    }
}