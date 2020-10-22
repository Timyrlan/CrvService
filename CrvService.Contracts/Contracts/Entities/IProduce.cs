using CrvService.Shared.Contracts.Entities.Cargos;

namespace CrvService.Shared.Contracts.Entities
{
    public interface IProduce
    {
        ICargo[] From { get; set; }
        ICargo[] To { get; set; }
        decimal Speed { get; set; }
    }
}