using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Base;
using CrvService.Shared.Contracts.Entities.Buildings.Base;
using CrvService.Shared.Logic.ClientSide.Base;
using CrvService.Shared.Logic.ClientSide.Buildings;

namespace CrvService.Shared.Logic.ClientSide
{
    public class CityClientSideEntity : ClientSideEntityBase, ICity
    {
        public bool Visible { get; set; }
        public float Size { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public string Name { get; set; }
        public ICollectionWrapper<IBuilding> Buildings { get; } = new ClientSideCollectionWrapper<IBuilding, BuildingClientSideEntity>();
    }
}