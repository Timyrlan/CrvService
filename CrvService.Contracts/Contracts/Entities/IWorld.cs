using System;
using CrvService.Shared.Contracts.Entities.Base;

namespace CrvService.Shared.Contracts.Entities
{
    public interface IWorld : IEntityBase
    {
        DateTime WorldDate { get; set; }
        ICollectionWrapper<ICity> Cities { get; }
    }
}