using System.Collections.Generic;
using System.Linq;
using CrvService.Shared.Contracts.Entities.Base;

namespace CrvService.Shared.Logic.ClientSide
{
    public class ClientSideCollectionWrapper<TInterface, TImplementation> : ICollectionWrapper<TInterface>
        where TInterface : IEntityBase
        where TImplementation : TInterface, new()
    {
        private List<TInterface> PrivateCollection { get; } = new List<TInterface>();

        public IEnumerable<TInterface> Collection => PrivateCollection;

        public void Remove(string guid)
        {
            var toRemove = PrivateCollection.FirstOrDefault(c => c.Guid == guid);

            if (toRemove != null) PrivateCollection.Remove(toRemove);
        }

        public void Add(TInterface entity)
        {
            PrivateCollection.Add(entity);
        }

        public void LoadCollection(IEnumerable<TInterface> collection)
        {
            PrivateCollection.Clear();
            PrivateCollection.AddRange(collection);
        }
    }
}