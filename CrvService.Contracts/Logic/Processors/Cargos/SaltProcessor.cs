using CrvService.Shared.Contracts.Entities.Cargos;
using CrvService.Shared.Logic.Processors.Base;

namespace CrvService.Shared.Logic.Processors.Cargos
{
    public class SaltProcessor : ProcessorBase
    {
        public SaltProcessor(IProcessorsProvider processorsProvider, INewInstanceFactory newInstanceFactory) : base(processorsProvider, newInstanceFactory)
        {
        }

        public override void Process(object c)
        {
            var casted = H.Cast<ISalt>(c);
            base.Process(casted);
        }
    }
}