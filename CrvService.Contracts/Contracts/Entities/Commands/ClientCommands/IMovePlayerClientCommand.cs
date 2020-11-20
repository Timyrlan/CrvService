using CrvService.Shared.Contracts.Entities.Commands.ClientCommands.Base;

namespace CrvService.Shared.Contracts.Entities.Commands.ClientCommands
{
    public interface IMovePlayerClientCommand : IClientCommand
    {
        float ToX { get; set; }
        float ToY { get; set; }
    }
}