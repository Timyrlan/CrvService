using CrvService.Shared.Contracts.Entities;

namespace CrvService.Shared.Logic.ClientSide
{
    public class ProcessWorldResponseClientSideEntity : IProcessWorldResponse
    {
        public IWorld World { get; set; }
        public IPlayer Player { get; set; }
    }
}