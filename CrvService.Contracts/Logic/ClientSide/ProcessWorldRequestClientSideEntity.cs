using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.ClientCommands.Base;
using CrvService.Shared.Logic.ClientSide.Base;

namespace CrvService.Shared.Logic.ClientSide
{
    public class ProcessWorldRequestClientSideEntity : ClientSideEntityBase, IProcessWorldRequest
    {
        public string WorldGuid { get; set; }
        public IPlayer Player { get; set; }
        public IClientCommand[] ClientCommands { get; set; } = { };
    }
}