using System;
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
            var casted = H.Cast<IPlayer>(c);
            base.Process(casted);

            //todo: visible cities

            if (casted.IsMoving) casted.IsMoving = !(Math.Abs(casted.X - casted.MoveToX) < 0.01) || !(Math.Abs(casted.Y - casted.MoveToY) < 0.01);
        }
    }
}