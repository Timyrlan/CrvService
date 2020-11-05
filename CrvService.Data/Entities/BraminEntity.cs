using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CrvService.Data.Entities.Cargos.Base;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Cargos.Base;
using CrvService.Shared.Logic;

namespace CrvService.Data.Entities
{
    public class BraminEntity : IBramin
    {
        public BraminEntity()
        {
            var c = H.InitializeBaseEntity(this);
            Type = c.Item1;
            Guid = c.Item2;
        }

        public int Id { get; set; }
        public string Guid { get; set; }
        public string Type { get; set; }
        public long Age { get; set; }

        #region Cargos

        private ICollectionWrapper<ICargo> _cargos;

        [NotMapped] public ICollectionWrapper<ICargo> Cargos => _cargos ??= new EntityCollectionWrapper<ICargo, CargoEntity>(CargoCollection);

        public virtual ICollection<CargoEntity> CargoCollection { get; set; } = new List<CargoEntity>();

        #endregion
    }
}