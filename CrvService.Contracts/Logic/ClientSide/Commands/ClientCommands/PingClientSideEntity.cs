using CrvService.Shared.Contracts.Entities.Commands.ClientCommands;
using CrvService.Shared.Logic.ClientSide.Commands.ClientCommands.Base;

namespace CrvService.Shared.Logic.ClientSide.Commands.ClientCommands
{
    public class PingClientSideEntity : ClientCommandClientSideEntity, IPing
    {
    }
}