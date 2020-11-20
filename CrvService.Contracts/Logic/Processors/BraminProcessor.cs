using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Logic.Processors.Base;

namespace CrvService.Shared.Logic.Processors
{
    public class BraminProcessor : CargoContainerProcessorBase
    {
        public BraminProcessor(IProcessorsProvider processorsProvider, INewInstanceFactory newInstanceFactory) : base(processorsProvider, newInstanceFactory)
        {
        }

        public override void Process(object c)
        {
            var casted = H.Cast<IBramin>(c);
            base.Process(casted);
            casted.Age++;
        }
    }
}