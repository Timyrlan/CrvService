using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Buildings;
using CrvService.Shared.Contracts.Entities.Buildings.Base;
using CrvService.Shared.Contracts.Entities.Cargos;
using CrvService.Shared.Contracts.Entities.Cargos.Base;
using CrvService.Shared.Logic.ClientSide.Base;
using CrvService.Shared.Logic.ClientSide.Cargos;

namespace CrvService.Shared.Logic.ClientSide.Buildings
{
    public class BuildingClientSideEntity : ClientSideEntityBase, IBuilding
    {
        public ICollectionWrapper<ICargo> Cargos { get; set; } = new ClientSideCollectionWrapper<ICargo, CargoClientSideEntity>();
    }
}