using System;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Logic.ClientSide.Base;

namespace CrvService.Shared.Logic.ClientSide
{
    public class WorldClientSideEntity : ClientSideEntityBase, IWorld
    {
        public ICollectionWrapper<ICity> Cities { get; } = new ClientSideCollectionWrapper<ICity, CityClientSideEntity>();
        public DateTime WorldDate { get; set; }
    }
}