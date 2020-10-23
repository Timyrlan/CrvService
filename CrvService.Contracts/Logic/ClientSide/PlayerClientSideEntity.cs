using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Logic.ClientSide.Base;

namespace CrvService.Shared.Logic.ClientSide
{
    public class PlayerClientSideEntity : ClientSideEntityBase, IPlayer
    {
        public string[] VisibleCities { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
    }
}