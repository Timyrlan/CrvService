using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Cargos.Base;
using CrvService.Shared.Logic.ClientSide.Cargos;

namespace CrvService.Shared.Logic.ClientSide.Base
{
    public class CargoContainerClientSideEntityBase : ClientSideEntityBase, ICargoContainer
    {
        public ICollectionWrapper<ICargo> Cargos { get; } = new ClientSideCollectionWrapper<ICargo, CargoClientSideEntity>();
    }
}