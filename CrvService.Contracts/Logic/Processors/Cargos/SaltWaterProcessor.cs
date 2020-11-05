using CrvService.Shared.Contracts.Entities.Cargos;
using CrvService.Shared.Logic.Processors.Base;

namespace CrvService.Shared.Logic.Processors.Cargos
{
    public class SaltWaterProcessor : ProcessorBase
    {
        public SaltWaterProcessor(IProcessorsProvider processorsProvider) : base(processorsProvider)
        {
        }

        public override void Process(object c)
        {
            var casted = H.Cast<ISaltWater>(c);
            base.Process(casted);
        }
    }
}