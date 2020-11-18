using System;
using System.Linq;
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
            var visibleCities = casted.VisibleCities.ToList();

            foreach (var worldCity in casted.PlayersWorld.Cities.Collection)
                if (!visibleCities.Contains(worldCity.Guid))
                    if (CoordinateHelper.GetDistance(casted.X, casted.Y, worldCity.X, worldCity.Y) < worldCity.Size * 2)
                        visibleCities.Add(worldCity.Guid);
            
            casted.VisibleCities = visibleCities.ToArray();

            if (casted.IsMoving) casted.IsMoving = !(Math.Abs(casted.X - casted.MoveToX) < 0.01) || !(Math.Abs(casted.Y - casted.MoveToY) < 0.01);
        }
    }
}