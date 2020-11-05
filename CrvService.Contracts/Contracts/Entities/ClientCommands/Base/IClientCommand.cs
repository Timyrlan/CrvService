using System;
using CrvService.Shared.Contracts.Entities.Base;

namespace CrvService.Shared.Contracts.Entities.ClientCommands.Base
{
    public interface IClientCommand : IEntityBase
    {
        bool Processed { get; set; }
        DateTime? ProcessDateTime { get; set; }
    }
}