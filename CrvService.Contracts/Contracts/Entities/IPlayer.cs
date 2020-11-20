using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Commands.ServerCommands.Base;

namespace CrvService.Shared.Contracts.Entities
{
    public interface IPlayer : IEntityBase
    {
        string UserGuid { get; set; }
        string[] VisibleCities { get; set; }

        float X { get; set; }
        float Y { get; set; }

        bool IsMoving { get; set; }

        float MoveToX { get; set; }
        float MoveToY { get; set; }

        string WorldGuid { get; set; }


        IWorld PlayersWorld { get; }

        ICollectionWrapper<IServerCommand> Commands { get; }
    }
}