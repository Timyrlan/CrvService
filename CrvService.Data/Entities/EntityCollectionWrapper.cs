using System.Collections.Generic;
using System.Linq;
using CrvService.Shared.Contracts.Entities.Base;

namespace CrvService.Data.Entities
{
    public class EntityCollectionWrapper<TInterface, TImplementation> : ICollectionWrapper<TInterface>
        where TInterface : IEntityBase
        where TImplementation : TInterface, new()
    {
        public EntityCollectionWrapper(ICollection<TImplementation> privateCollection)
        {
            PrivateCollection = privateCollection;
        }

        private ICollection<TImplementation> PrivateCollection { get; }

        public IEnumerable<TInterface> Collection => PrivateCollection.Select(c => (TInterface) c);

        public void Remove(string guid)
        {
            var toRemove = PrivateCollection.FirstOrDefault(c => c.Guid == guid);

            if (toRemove != null) PrivateCollection.Remove(toRemove);
        }

        public void Add(TInterface entity)
        {
            PrivateCollection.Add((TImplementation) entity);
        }

        public void LoadCollection(IEnumerable<TInterface> collection)
        {
            PrivateCollection.Clear();
            foreach (var c in collection) PrivateCollection.Add((TImplementation) c);
        }
    }
}