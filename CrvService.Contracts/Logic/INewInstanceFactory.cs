using CrvService.Shared.Contracts.Entities.Base;

namespace CrvService.Shared.Logic
{
    public interface INewInstanceFactory
    {
        T GetNewInstance<T>(string type) where T : class, IEntityBase;
    }
}