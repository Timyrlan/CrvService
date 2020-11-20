using System;
using CrvService.Shared.Contracts.Entities.Commands.ServerCommands.Base;
using CrvService.Shared.Logic;

namespace CrvService.Data.Entities.Commands.ServerCommands.Base
{
    public class ServerCommandEntity : IServerCommand
    {
        public ServerCommandEntity()
        {
            var c = H.InitializeBaseEntity(this);
            Type = c.Item1;
            Guid = c.Item2;
        }

        public int Id { get; set; }
        public string WorldGuid { get; set; }

        public int PlayerId { get; set; }
        public PlayerEntity Player { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;
        public string PlayerGuid { get; set; }

        public string Guid { get; set; }
        public string Type { get; set; }
        public bool Processed { get; set; }
        public DateTime? ProcessDateTime { get; set; }
    }
}