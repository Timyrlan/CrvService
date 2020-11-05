using CrvService.Shared.Contracts.Entities;

namespace CrvService.Data.Entities
{
    public class ProcessWorldResponseEntity : IProcessWorldResponse
    {
        public IWorld World { get; set; }
        public IPlayer Player { get; set; }
    }
}