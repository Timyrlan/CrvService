using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CrvService.Data.Entities.Buildings.Base;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Buildings.Base;
using CrvService.Shared.Logic;

namespace CrvService.Data.Entities
{
    public class CityEntity : ICity
    {
        public CityEntity()
        {
            var c = H.InitializeBaseEntity(this);
            Type = c.Item1;
            Guid = c.Item2;
        }

        public int Id { get; set; }
        public string Guid { get; set; }
        public string Type { get; set; }
        public float Size { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public string Name { get; set; }

        #region Building

        private ICollectionWrapper<IBuilding> _buildings;

        [NotMapped] public ICollectionWrapper<IBuilding> Buildings => _buildings ??= new EntityCollectionWrapper<IBuilding, BuildingEntity>(BuildingCollection);

        public virtual ICollection<BuildingEntity> BuildingCollection { get; set; } = new List<BuildingEntity>();

        #endregion
    }
}