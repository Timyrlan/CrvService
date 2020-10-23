using CrvService.Shared.Contracts.Entities.Base;

namespace CrvService.Shared.Contracts.Entities
{
    public interface IPlayer : IEntityBase
    {
        string[] VisibleCities { get; set; }

        float X { get; set; }
        float Y { get; set; }
    }
}