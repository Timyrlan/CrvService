using CrvService.Shared.Contracts.Entities.ClientCommands;

namespace CrvService.Data.Entities
{
    public class MovePlayerClientCommandEntity : ClientCommandEntity, IMovePlayerClientCommand
    {
        public float ToX { get; set; }
        public float ToY { get; set; }
    }
}