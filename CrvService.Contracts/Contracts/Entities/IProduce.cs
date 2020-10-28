using CrvService.Shared.Contracts.Entities.Cargos;
using CrvService.Shared.Contracts.Entities.Cargos.Base;

namespace CrvService.Shared.Contracts.Entities
{
    public interface IProduce
    {
        ICargo[] From { get; set; }
        ICargo[] To { get; set; }
        decimal Speed { get; set; }
    }
}