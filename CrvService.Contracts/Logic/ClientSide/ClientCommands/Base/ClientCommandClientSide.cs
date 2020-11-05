using System;
using CrvService.Shared.Contracts.Entities.ClientCommands.Base;
using CrvService.Shared.Logic.ClientSide.Base;

namespace CrvService.Shared.Logic.ClientSide.ClientCommands.Base
{
    public class ClientCommandClientSideEntity : ClientSideEntityBase, IClientCommand
    {
        public bool Processed { get; set; }
        public DateTime? ProcessDateTime { get; set; }
    }
}