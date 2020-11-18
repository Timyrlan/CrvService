using CrvService.Shared.Contracts.Entities;

namespace CrvService.Shared.Logic.ClientSide
{
    public class GetNewWorldRequestClientSideEntity : IGetNewWorldRequest
    {
        public string UserGuid { get; set; }
    }
}