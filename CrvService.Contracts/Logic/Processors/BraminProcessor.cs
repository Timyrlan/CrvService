using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Logic.Processors.Base;

namespace CrvService.Shared.Logic.Processors
{
    public class BraminProcessor : CargoContainerProcessorBase
    {
        public BraminProcessor(IProcessorsProvider processorsProvider) : base(processorsProvider)
        {
        }

        public override void Process(object c)
        {
            var casted = Cast<IBramin>(c);
            base.Process(casted);
            casted.Age++;
        }
    }
}