using Microsoft.Extensions.Logging;

namespace CrvService.Logging
{
    public class LogLevelClass
    {
        public LogLevel Default { get; set; }
        public LogLevel System { get; set; }
        public LogLevel Microsoft { get; set; }
        public LogLevel Gg { get; set; } = LogLevel.Trace;
        public LogLevel GgDb { get; set; } = LogLevel.Error;
    }
}