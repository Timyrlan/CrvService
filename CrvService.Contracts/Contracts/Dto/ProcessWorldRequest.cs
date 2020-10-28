using CrvService.Shared.Contracts.Dto.ClientCommands.Base;

namespace CrvService.Shared.Contracts.Dto
{
    public class ProcessWorldRequest
    {
        public ClientCommandDto[] ClientCommands = { };

        public PlayerDto Player;
        public string WorldGuid;
    }
}