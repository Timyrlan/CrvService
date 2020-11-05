using System.Linq;
using CrvService.Common.Options;

namespace CrvService.Common
{
    public interface IPeriodicServiceRepository
    {
        IQueryable<PeriodicServiceEntity> Services { get; }
        void Update(PeriodicServiceOptions options, long iteration);
        void UpdateRun(PeriodicServiceOptions options, long iteration, long runDuration, string error);
    }
}