using CrvService.Shared.Contracts.Entities.ClientCommands.Base;
using CrvService.Shared.Logic;

namespace CrvService.Data.Entities
{
    public class ClientCommandEntity : IClientCommand
    {
        public ClientCommandEntity()
        {
            var c = H.InitializeBaseEntity(this);
            Type = c.Item1;
            Guid = c.Item2;
        }

        public int Id { get; set; }
        public int WorldId { get; set; }
        public string WorldGuid { get; set; }

        public int PlayerId { get; set; }
        public string PlayerGuid { get; set; }

        public string Guid { get; set; }
        public string Type { get; set; }
    }
}