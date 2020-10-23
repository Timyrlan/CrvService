namespace CrvService.Shared.Contracts.Entities.Base
{
    public interface IEntityBase : IGuidEntity
    {
        string Type { get; set; }
    }
}