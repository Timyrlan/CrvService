using CrvService.Shared.Contracts.Entities.ClientCommands.Base;

namespace CrvService.Shared.Contracts.Entities
{
    public interface IProcessWorldRequest
    {
        string WorldGuid { get; set; }

        IPlayer Player { get; set; }

        IClientCommand[] ClientCommands { get; set; }
    }
}