using System.Collections.Generic;

namespace CrvService.Shared.Contracts.Entities.Base
{
    public interface ICollectionWrapper<TClass> where TClass : IGuidEntity
    {
        IEnumerable<TClass> Collection { get; }
        TClass GetNew();
        void Remove(string guid);
        void Add(TClass entity);
    }
}