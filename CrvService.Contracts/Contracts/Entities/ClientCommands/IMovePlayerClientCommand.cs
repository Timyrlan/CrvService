using CrvService.Shared.Contracts.Entities.ClientCommands.Base;

namespace CrvService.Shared.Contracts.Entities.ClientCommands
{
    public interface IMovePlayerClientCommand : IClientCommand
    {
        float ToX { get; set; }
        float ToY { get; set; }
    }
}