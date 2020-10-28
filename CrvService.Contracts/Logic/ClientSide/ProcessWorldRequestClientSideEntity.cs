using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.ClientCommands.Base;

namespace CrvService.Shared.Logic.ClientSide
{
    public class ProcessWorldRequestClientSideEntity : IProcessWorldRequest
    {
        public string WorldGuid { get; set; }
        public IPlayer Player { get; set; }
        public IClientCommand[] ClientCommands { get; set; } = { };
    }
}