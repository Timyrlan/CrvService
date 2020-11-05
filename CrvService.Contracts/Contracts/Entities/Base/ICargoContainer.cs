using CrvService.Shared.Contracts.Entities.Cargos.Base;

namespace CrvService.Shared.Contracts.Entities.Base
{
    public interface ICargoContainer : IEntityBase
    {
        ICollectionWrapper<ICargo> Cargos { get; }
    }
}