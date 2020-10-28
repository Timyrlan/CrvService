using CrvService.Shared.Contracts.Entities.Buildings;
using CrvService.Shared.Contracts.Entities.Buildings.Base;

namespace CrvService.Shared.Logic.Processors.Base
{
    public abstract class BuildingProcessor : ProducibleProcessor
    {
        public BuildingProcessor(IProcessorsProvider processorsProvider, INewInstanceFactory newInstanceFactory) : base(processorsProvider, newInstanceFactory)
        {
        }

        public override void Process(object entity)
        {
            var casted = Cast<IBuilding>(entity);
            base.Process(casted);
        }
    }
}