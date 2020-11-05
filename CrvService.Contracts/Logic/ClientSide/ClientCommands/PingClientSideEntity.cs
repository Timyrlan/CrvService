using CrvService.Shared.Contracts.Entities.ClientCommands;
using CrvService.Shared.Logic.ClientSide.ClientCommands.Base;

namespace CrvService.Shared.Logic.ClientSide.ClientCommands
{
    public class PingClientSideEntity : ClientCommandClientSideEntity, IPing
    {
    }
}