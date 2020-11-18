using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Logic.ClientSide.Base;

namespace CrvService.Shared.Logic.ClientSide
{
    public class PlayerClientSideEntity : ClientSideEntityBase, IPlayer
    {
        public string UserGuid { get; set; }
        public string[] VisibleCities { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public bool IsMoving { get; set; }
        public float MoveToX { get; set; }
        public float MoveToY { get; set; }
        public string WorldGuid { get; set; }
        public IWorld PlayersWorld { get; set; }
    }
}