using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Cargos;
using CrvService.Shared.Logic.ClientSide.Base;
using CrvService.Shared.Logic.ClientSide.Cargos;

namespace CrvService.Shared.Logic.ClientSide
{
    public class BraminClientSideEntity : ClientSideEntityBase, IBramin
    {
        public ICollectionWrapper<ICargo> Cargos { get; } = new ClientSideCollectionWrapper<ICargo, CargoClientSideEntity>();
        public long Age { get; set; }
    }
}