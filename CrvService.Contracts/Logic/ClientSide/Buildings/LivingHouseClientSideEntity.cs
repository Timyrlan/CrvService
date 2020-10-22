using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Buildings;
using CrvService.Shared.Contracts.Entities.Cargos;
using CrvService.Shared.Logic.ClientSide.Base;
using CrvService.Shared.Logic.ClientSide.Cargos;

namespace CrvService.Shared.Logic.ClientSide.Buildings
{
    public class LivingHouseClientSideEntity : ClientSideEntityBase, ILivingHouse
    {
        public ICollectionWrapper<ICargo> Cargos { get; set; } = new ClientSideCollectionWrapper<ICargo, CargoClientSideEntity>();
    }
}