using Newtonsoft.Json;

namespace CrvService.Common.Options
{
    public abstract class ServiceOptions
    {
        public static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore};
        public virtual bool Enabled { get; set; } = true;
        public abstract string ServiceName { get; }
    }
}