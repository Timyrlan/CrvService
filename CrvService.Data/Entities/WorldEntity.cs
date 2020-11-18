using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Logic;

namespace CrvService.Data.Entities
{
    public class WorldEntity : IWorld
    {
        public WorldEntity()
        {
            var c = H.InitializeBaseEntity(this);
            Type = c.Item1;
            Guid = c.Item2;
        }

        public int Id { get; set; }


        public string Guid { get; set; }
        public string Type { get; set; }
        public DateTime WorldDate { get; set; }

        #region City

        private ICollectionWrapper<ICity> _cities;
        private ICollectionWrapper<IPlayer> _players;
        [NotMapped] public ICollectionWrapper<ICity> Cities => _cities ??= new EntityCollectionWrapper<ICity, CityEntity>(CityCollection);
        public virtual ICollection<CityEntity> CityCollection { get; set; } = new List<CityEntity>();

        [NotMapped] public ICollectionWrapper<IPlayer> Players => _players ??= new EntityCollectionWrapper<IPlayer, PlayerEntity>(PlayerCollection);
        public virtual ICollection<PlayerEntity> PlayerCollection { get; set; } = new List<PlayerEntity>();

        #endregion
    }
}