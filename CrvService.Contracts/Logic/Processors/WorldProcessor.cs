using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Logic.Processors.Base;

namespace CrvService.Shared.Logic.Processors
{
    public class WorldProcessor : ProcessorBase
    {
        public WorldProcessor(IProcessorsProvider processorsProvider) : base(processorsProvider)
        {
        }


        public override void Process(object c)
        {
            var casted = H.Cast<IWorld>(c);
            base.Process(casted);

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            casted.WorldDate = casted.WorldDate.AddSeconds(1);

            foreach (var city in casted.Cities.Collection) ProcessorsProvider.Process(city);
        }
    }
}