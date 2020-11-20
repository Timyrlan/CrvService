using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Logic.Processors.Base;

namespace CrvService.Shared.Logic.Processors
{
    public class CityProcessor : ProcessorBase
    {
        public CityProcessor(IProcessorsProvider processorsProvider, INewInstanceFactory newInstanceFactory) : base(processorsProvider, newInstanceFactory)
        {
        }


        public override void Process(object c)
        {
            var casted = H.Cast<ICity>(c);
            base.Process(casted);

            foreach (var building in casted.Buildings.Collection) ProcessorsProvider.Process(building);
        }
    }
}