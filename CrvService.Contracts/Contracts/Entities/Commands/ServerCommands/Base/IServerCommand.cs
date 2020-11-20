using System;
using CrvService.Shared.Contracts.Entities.Base;

namespace CrvService.Shared.Contracts.Entities.Commands.ServerCommands.Base
{
    public interface IServerCommand : IEntityBase
    {
        int Id { get; set; }
        bool Processed { get; set; }
        DateTime? ProcessDateTime { get; set; }
        string PlayerGuid { get; set; }
        string WorldGuid { get; set; }
    }
}