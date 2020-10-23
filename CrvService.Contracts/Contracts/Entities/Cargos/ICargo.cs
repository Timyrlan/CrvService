using CrvService.Shared.Contracts.Entities.Base;

namespace CrvService.Shared.Contracts.Entities.Cargos
{
    public interface ICargo : IEntityBase
    {
        decimal Count { get; set; }
    }
}