using System;
using CrvService.Shared.Contracts.Entities.Commands.ServerCommands.Base;
using CrvService.Shared.Logic.ClientSide.Base;

namespace CrvService.Shared.Logic.ClientSide.Commands.ServerCommands.Base
{
    public class ServerCommandClientSideEntity : ClientSideEntityBase, IServerCommand
    {
        public int Id { get; set; }
        public bool Processed { get; set; }
        public DateTime? ProcessDateTime { get; set; }
        public string PlayerGuid { get; set; }
        public string WorldGuid { get; set; }
    }
}