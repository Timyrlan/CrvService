using CrvService.Shared.Contracts.Dto.Base;
using CrvService.Shared.Contracts.Dto.Cargos;

namespace CrvService.Shared.Contracts.Dto
{
    public class BraminDto : DtoBase
    {
        public long Age;
        public CargoDto[] Cargos = { };
    }
}