using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Buildings;
using CrvService.Shared.Contracts.Entities.Cargos;
using CrvService.Shared.Contracts.Entities.Cargos.Base;
using CrvService.Shared.Logic.ClientSide;
using CrvService.Shared.Logic.ClientSide.Cargos;
using CrvService.Shared.Logic.Processors.Base;

namespace CrvService.Shared.Logic.Processors.Buildings
{
    public class LivingHouseProcessor : BuildingProcessor
    {
        public LivingHouseProcessor(IProcessorsProvider processorsProvider, INewInstanceFactory newInstanceFactory) : base(processorsProvider, newInstanceFactory)
        {
        }

        public override IProduce[] Produces { get; set; } =
        {
            new ProduceClientSideEntity {From = new ICargo[] {new FreshWaterClientSideEntity {Count = 1m}}, Speed = 0.01m}
        };

        public override void Process(object entity)
        {
            var casted = H.Cast<ILivingHouse>(entity);
            base.Process(casted);
        }
    }
}