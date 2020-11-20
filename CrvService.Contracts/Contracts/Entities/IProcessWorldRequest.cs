using CrvService.Shared.Contracts.Entities.Commands.ClientCommands.Base;

namespace CrvService.Shared.Contracts.Entities
{
    public interface IProcessWorldRequest
    {
        string WorldGuid { get; set; }

        IPlayer Player { get; set; }

        IClientCommand[] ClientCommands { get; set; }

        int LastServerCommandProcessed { get; set; }
    }
}