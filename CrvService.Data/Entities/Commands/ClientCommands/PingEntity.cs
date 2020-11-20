using CrvService.Data.Entities.Commands.ClientCommands.Base;
using CrvService.Shared.Contracts.Entities.Commands.ClientCommands;

namespace CrvService.Data.Entities.Commands.ClientCommands
{
    public class PingEntity : ClientCommandEntity, IPing
    {
    }
}