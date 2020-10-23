using System.Collections.Generic;
using System.Linq;
using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Cargos;

namespace CrvService.Shared.Logic.Processors.Base
{
    public abstract class CargoContainerProcessorBase : ProcessorBase
    {
        protected CargoContainerProcessorBase(IProcessorsProvider processorsProvider) : base(processorsProvider)
        {
        }

        public virtual Dictionary<string, decimal> CanStoreCargos { get; set; } = new Dictionary<string, decimal>();

        protected virtual void ProcessCargos(ICargoContainer entity)
        {
            foreach (var cargo in entity.Cargos.Collection) ProcessorsProvider.Process(cargo);
        }

        public override void Process(object entity)
        {
            var casted = Cast<ICargoContainer>(entity);
            base.Process(casted);
            ProcessCargos(casted);
        }

        public virtual decimal CanAddCargoMore(string type, ICargoContainer container)
        {
            if (!CanStoreCargos.TryGetValue(type, out var canStoreAtAll)) return 0;

            var count = GetFullCargoCount(type, container);

            var result = canStoreAtAll - count;

            return result > 0 ? result : 0;
        }

        public bool AddCargo(ICargo cargo, ICargoContainer container)
        {
            if (CanAddCargoMore(cargo.Type, container) < cargo.Count) return false;


            var existedCargo = container.Cargos.Collection.FirstOrDefault(c => c.Type == cargo.Type);

            if (existedCargo != null)
                existedCargo.Count += cargo.Count;
            else
                container.Cargos.Add(cargo);

            return true;
        }

        public decimal GetFullCargoCount(string type, ICargoContainer container)
        {
            return container.Cargos.Collection.Where(c => c.Type == type).Sum(c => c.Count);
        }
    }
}