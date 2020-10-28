namespace CrvService.Shared.Contracts.Entities
{
    public interface IProcessWorldResponse
    {
        IWorld World { get; set; }

        IPlayer Player { get; set; }
    }
}