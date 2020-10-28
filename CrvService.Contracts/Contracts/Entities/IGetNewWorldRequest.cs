namespace CrvService.Shared.Contracts.Entities
{
    public interface IGetNewWorldRequest
    {
        IPlayer Player { get; set; }
    }
}