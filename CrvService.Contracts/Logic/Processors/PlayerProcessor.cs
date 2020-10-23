using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Logic.Processors.Base;

namespace CrvService.Shared.Logic.Processors
{
    public class PlayerProcessor : ProcessorBase
    {
        public PlayerProcessor(IProcessorsProvider processorsProvider) : base(processorsProvider)
        {
        }


        public override void Process(object c)
        {
            var casted = Cast<IPlayer>(c);
            base.Process(casted);
        }
    }
}