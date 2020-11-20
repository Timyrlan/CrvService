using CrvService.Shared.Contracts.Entities.Commands.ClientCommands;
using CrvService.Shared.Logic.ClientSide.Commands.ClientCommands.Base;

namespace CrvService.Shared.Logic.ClientSide.Commands.ClientCommands
{
    public class MovePlayerClientCommandClientSideEntity : ClientCommandClientSideEntity, IMovePlayerClientCommand
    {
        public float ToX { get; set; }
        public float ToY { get; set; }
    }
}