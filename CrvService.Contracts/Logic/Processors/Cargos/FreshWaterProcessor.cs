using CrvService.Shared.Contracts.Entities.Cargos;
using CrvService.Shared.Logic.Processors.Base;

namespace CrvService.Shared.Logic.Processors.Cargos
{
    public class FreshWaterProcessor : ProcessorBase
    {
        public FreshWaterProcessor(IProcessorsProvider processorsProvider) : base(processorsProvider)
        {
        }

        public override void Process(object c)
        {
            var casted = Cast<IFreshWater>(c);
            base.Process(casted);
        }
    }
}