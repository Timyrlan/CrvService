using CrvService.Shared.Contracts.Entities;

namespace CrvService.Shared.Logic.ClientSide
{
    public class GetNewWorldRequestClientSideEntity : IGetNewWorldRequest
    {
        public IPlayer Player { get; set; }
    }
}