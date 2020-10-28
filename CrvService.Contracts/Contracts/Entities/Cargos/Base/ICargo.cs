using CrvService.Shared.Contracts.Entities.Base;

namespace CrvService.Shared.Contracts.Entities.Cargos.Base
{
    public interface ICargo : IEntityBase
    {
        decimal Count { get; set; }
    }
}