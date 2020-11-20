using CrvService.Shared.Contracts.Dto.Base;

namespace CrvService.Shared.Contracts.Dto.Commands.ClientCommands.Base
{
    public class ClientCommandDto : DtoBase
    {
        public float ToX { get; set; }
        public float ToY { get; set; }
    }
}