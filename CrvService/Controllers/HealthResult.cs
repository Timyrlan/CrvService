using System;
using System.Reflection;

namespace CrvService.Controllers
{
    public class HealthResult
    {
        public enum HealthStatus
        {
            Ok = 200,
            InternalServerError = 500,
            Loading = 1000
        }

        public int Code { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }

        public string ApplicationVersion => Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

        public DateTime LocalDateTimeUtc => DateTime.UtcNow;
    }
}