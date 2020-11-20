using CrvService.Shared.Contracts.Dto.Commands.ClientCommands.Base;

namespace CrvService.Shared.Contracts.Dto
{
    public class ProcessWorldRequest
    {
        public ClientCommandDto[] ClientCommands = { };

        public PlayerDto Player;
        public string WorldGuid;
        public int LastServerCommandProcessed { get; set; }
    }
}