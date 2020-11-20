using System;
using CrvService.Shared.Contracts.Entities.Commands.ClientCommands.Base;
using CrvService.Shared.Logic.ClientSide.Base;

namespace CrvService.Shared.Logic.ClientSide.Commands.ClientCommands.Base
{
    public class ClientCommandClientSideEntity : ClientSideEntityBase, IClientCommand
    {
        public bool Processed { get; set; }
        public DateTime? ProcessDateTime { get; set; }
    }
}