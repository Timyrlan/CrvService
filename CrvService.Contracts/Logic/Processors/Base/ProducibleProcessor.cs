using System;
using System.Linq;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Cargos;

namespace CrvService.Shared.Logic.Processors.Base
{
    public abstract class ProducibleProcessor : CargoContainerProcessorBase
    {
        protected ProducibleProcessor(IProcessorsProvider processorsProvider, INewInstanceFactory newInstanceFactory) : base(processorsProvider)
        {
            NewInstanceFactory = newInstanceFactory;
        }

        protected INewInstanceFactory NewInstanceFactory { get; }

        public virtual IProduce[] Produces { get; set; } = { };

        public override void Process(object entity)
        {
            var casted = Cast<ICargoContainer>(entity);
            base.Process(casted);
            Produce(casted);
        }

        protected void Produce(ICargoContainer cargoContainer)
        {
            foreach (var produce in Produces) Produce(produce, cargoContainer);
        }

        private void Produce(IProduce produce, ICargoContainer container)
        {
            if (produce == null) throw new ArgumentNullException(nameof(produce));

            if (!produce.From.Any() && !produce.To.Any()) return;

            //проверяем, что ингридиентов достаточно, чтобы приготовить
            foreach (var cargoFrom in produce.From)
            {
                var fromCargo = container.Cargos.Collection.FirstOrDefault(c => c.Type == cargoFrom.Type);

                if (fromCargo == null) return;

                if (fromCargo.Count < cargoFrom.Count * produce.Speed) return;
            }

            //проверяем, что место достаточно, чтобы хранить ингридиенты
            foreach (var cargoTo in produce.To)
            {
                var count = cargoTo.Count * produce.Speed;
                if (count > CanAddCargoMore(cargoTo.Type, container)) return;
            }

            //тратим ингридиенты
            foreach (var cargoFrom in produce.From)
            {
                var fromCargo = container.Cargos.Collection.First(c => c.Type == cargoFrom.Type);
                fromCargo.Count -= cargoFrom.Count * produce.Speed;
            }

            //создаем ингридиенты
            foreach (var cargoTo in produce.To)
            {
                var cargoToAdd = NewInstanceFactory.GetNewInstance<ICargo>(cargoTo.Type);


                cargoToAdd.Count = cargoTo.Count * produce.Speed;

                AddCargo(cargoToAdd, container);
            }
        }
    }
}