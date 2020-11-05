using System;
using System.Collections.Concurrent;
using System.Linq;
using CrvService.Common.Options;
using Newtonsoft.Json;

namespace CrvService.Common
{
    public class PeriodicServiceRepository : IPeriodicServiceRepository
    {
        private static JsonSerializerSettings JsonSerializerSettings { get; } = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Include,
            Formatting = Formatting.None,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        private ConcurrentDictionary<string, PeriodicServiceEntity> ServicesDictionary { get; } = new ConcurrentDictionary<string, PeriodicServiceEntity>();

        public IQueryable<PeriodicServiceEntity> Services => ServicesDictionary.Select(c => c.Value).AsQueryable();

        public void Update(PeriodicServiceOptions options, long iteration)
        {
            if (options == null) throw new ArgumentException(nameof(options));

            if (string.IsNullOrWhiteSpace(options.ServiceName)) throw new Exception("options.ServiceName is empty");

            ServicesDictionary.AddOrUpdate(options.ServiceName, s => AddService(s, options, iteration), (s, entity) => UpdateService(s, entity, options, iteration));
        }

        public void UpdateRun(PeriodicServiceOptions options, long iteration, long runDuration, string error)
        {
            if (options == null) throw new ArgumentException(nameof(options));

            if (string.IsNullOrWhiteSpace(options.ServiceName)) throw new Exception("options.ServiceName is empty");

            ServicesDictionary.AddOrUpdate(options.ServiceName, s => AddService(s, options, iteration), (s, entity) => UpdateRunService(s, entity, options, iteration, runDuration, error));
        }

        private static string Serialize(object viewModel)
        {
            return JsonConvert.SerializeObject(viewModel, JsonSerializerSettings).Replace("True", "true", StringComparison.InvariantCulture).Replace("False", "false", StringComparison.InvariantCulture);
        }

        private PeriodicServiceEntity AddService(string key, PeriodicServiceOptions options, long iteration)
        {
            var result = new PeriodicServiceEntity
            {
                Name = key,
                Added = DateTime.UtcNow,
                ServiceType = options.ServiceType
            };

            result = UpdateService(key, result, options, iteration);
            return result;
        }

        private PeriodicServiceEntity UpdateService(string key, PeriodicServiceEntity e, PeriodicServiceOptions options, long iteration)
        {
            e.Enabled = options.Enabled;
            e.Updated = DateTime.UtcNow;
            e.Iteration = iteration;
            e.PeriodMilliseconds = options.PeriodMilliseconds;
            e.Options = Serialize(options);
            return e;
        }

        private PeriodicServiceEntity UpdateRunService(string key, PeriodicServiceEntity e, PeriodicServiceOptions options, long iteration, long runDuration, string error)
        {
            var result = UpdateService(key, e, options, iteration);
            result.LastRun = DateTime.UtcNow;
            result.LastRunDurationMilliseconds = runDuration;
            result.LastRunError = error;
            return result;
        }
    }
}