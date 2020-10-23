using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Cargos;

namespace CrvService.Shared.Logic.ClientSide
{
    public class ProduceClientSideEntity : IProduce
    {
        public ICargo[] From { get; set; } = { };
        public ICargo[] To { get; set; } = { };
        public decimal Speed { get; set; }
    }
}