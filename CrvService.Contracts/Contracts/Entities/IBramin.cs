using CrvService.Shared.Contracts.Entities.Base;

namespace CrvService.Shared.Contracts.Entities
{
    public interface IBramin : ICargoContainer
    {
       
        long Age { get; set; }
    }
}