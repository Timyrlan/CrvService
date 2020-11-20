using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Commands.ServerCommands.Base;
using CrvService.Shared.Logic.ClientSide.Base;
using CrvService.Shared.Logic.ClientSide.Commands.ServerCommands.Base;

namespace CrvService.Shared.Logic.ClientSide
{
    public class PlayerClientSideEntity : ClientSideEntityBase, IPlayer
    {
        public string UserGuid { get; set; }
        public string[] VisibleCities { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public bool IsMoving { get; set; }
        public float MoveToX { get; set; }
        public float MoveToY { get; set; }
        public string WorldGuid { get; set; }
        public IWorld PlayersWorld { get; set; }
        public ICollectionWrapper<IServerCommand> Commands { get; } = new ClientSideCollectionWrapper<IServerCommand, ServerCommandClientSideEntity>();
    }
}