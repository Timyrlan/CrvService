using CrvService.Data.Entities.Commands.ClientCommands.Base;
using CrvService.Shared.Contracts.Entities.Commands.ClientCommands;

namespace CrvService.Data.Entities.Commands.ClientCommands
{
    public class MovePlayerClientCommandEntity : ClientCommandEntity, IMovePlayerClientCommand
    {
        public float ToX { get; set; }
        public float ToY { get; set; }
    }
}