using CrvService.Shared.Contracts.Entities.Cargos.Base;
using CrvService.Shared.Logic.ClientSide.Base;

namespace CrvService.Shared.Logic.ClientSide.Cargos
{
    public class CargoClientSideEntity : ClientSideEntityBase, ICargo
    {
        public decimal Count { get; set; }
    }
}