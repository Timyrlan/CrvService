using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Cargos;
using CrvService.Shared.Logic.ClientSide.Cargos;

namespace CrvService.Shared.Logic.ClientSide.Base
{
    public class CargoContainerClientSideEntityBase : ClientSideEntityBase, ICargoContainer
    {
        public ICollectionWrapper<ICargo> Cargos { get; set; } = new ClientSideCollectionWrapper<ICargo, CargoClientSideEntity>();
    }
}