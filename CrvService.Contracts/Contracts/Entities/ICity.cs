﻿using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Buildings.Base;

namespace CrvService.Shared.Contracts.Entities
{
    public interface ICity : IEntityBase
    {
        float Size { get; set; }
        float X { get; set; }
        float Y { get; set; }
        string Name { get; set; }


        ICollectionWrapper<IBuilding> Buildings { get; }
    }
}