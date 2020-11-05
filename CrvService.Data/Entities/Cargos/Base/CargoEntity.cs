using CrvService.Shared.Contracts.Entities.Cargos.Base;
using CrvService.Shared.Logic;

namespace CrvService.Data.Entities.Cargos.Base
{
    public class CargoEntity : ICargo
    {
        public CargoEntity()
        {
            var c = H.InitializeBaseEntity(this);
            Type = c.Item1;
            Guid = c.Item2;
        }

        public int Id { get; set; }
        public decimal Count { get; set; }
        public string Guid { get; set; }
        public string Type { get; set; }
    }
}