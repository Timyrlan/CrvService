using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CrvService.Data.Entities.Commands.ServerCommands.Base;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Commands.ServerCommands.Base;
using CrvService.Shared.Logic;

namespace CrvService.Data.Entities
{
    public class PlayerEntity : IPlayer
    {
        public PlayerEntity()
        {
            var c = H.InitializeBaseEntity(this);
            Type = c.Item1;
            Guid = c.Item2;
        }

        public int Id { get; set; }

        public string VisibleCitiesStr { get; set; }

        public WorldEntity World { get; set; }


        public string Guid { get; set; }
        public string Type { get; set; }

        public string UserGuid { get; set; }

        [NotMapped]
        public string[] VisibleCities
        {
            get => VisibleCitiesStr?.Split(',');
            set => VisibleCitiesStr = value == null ? VisibleCitiesStr = null : VisibleCitiesStr = string.Join(',', value);
        }

        public float X { get; set; }
        public float Y { get; set; }
        public bool IsMoving { get; set; }
        public float MoveToX { get; set; }
        public float MoveToY { get; set; }

        public string WorldGuid { get; set; }

        [NotMapped]
        public IWorld PlayersWorld
        {
            get => World;
            set => World = (WorldEntity) value;
        }

        #region Commands

        public virtual ICollection<ServerCommandEntity> CommandsCollection { get; set; } = new List<ServerCommandEntity>();
        private ICollectionWrapper<IServerCommand> _commands;
        [NotMapped] public ICollectionWrapper<IServerCommand> Commands => _commands ??= new EntityCollectionWrapper<IServerCommand, ServerCommandEntity>(CommandsCollection);

        #endregion
    }
}