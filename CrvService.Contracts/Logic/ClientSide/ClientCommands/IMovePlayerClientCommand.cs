using CrvService.Shared.Contracts.Entities.ClientCommands;
using CrvService.Shared.Logic.ClientSide.ClientCommands.Base;

namespace CrvService.Shared.Logic.ClientSide.ClientCommands
{
    public class MovePlayerClientCommandClientSide : ClientCommandClientSide, IMovePlayerClientCommand
    {
        public float ToX { get; set; }
        public float ToY { get; set; }
    }
}