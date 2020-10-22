using CrvService.Shared.Contracts.Entities.Cargos;

namespace CrvService.Shared.Contracts.Entities.Base
{
    public interface ICargoContainer : IEntityBase
    {
        ICollectionWrapper<ICargo> Cargos { get; }
    }
}