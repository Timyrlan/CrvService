using System.Linq;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Commands.ServerCommands;
using CrvService.Shared.Logic.Processors.Base;

namespace CrvService.Shared.Logic.Processors
{
    public class PlayerProcessor : ProcessorBase
    {
        public PlayerProcessor(IProcessorsProvider processorsProvider, INewInstanceFactory newInstanceFactory) : base(processorsProvider, newInstanceFactory)
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

            if (casted.IsMoving)
            {
                casted.IsMoving = !CoordinateHelper.IsInRadius(casted.X, casted.Y, casted.MoveToX, casted.MoveToY, 0.01f); // !(Math.Abs(casted.X - casted.MoveToX) < 0.01) || !(Math.Abs(casted.Y - casted.MoveToY) < 0.01);

                if (!casted.IsMoving) ProcessStop(casted);
            }
        }

        private void ProcessStop(IPlayer player)
        {
            var city = FindCityToEnter(player);
            if (city != null)
            {
                var command = NewInstanceFactory.GetNewInstance<IEnterCityServerCommand>();
                command.WorldGuid = player.PlayersWorld.Guid;
                command.PlayerGuid = player.Guid;
                player.Commands.Add(command);
            }
        }

        private ICity FindCityToEnter(IPlayer player)
        {
            foreach (var city in player.PlayersWorld.Cities.Collection)
                if (player.VisibleCities.Any(c => c == city.Guid) && CoordinateHelper.IsInRadius(player.X, player.Y, city.X, city.Y, city.Size))
                    return city;

            return null;
        }
    }
}