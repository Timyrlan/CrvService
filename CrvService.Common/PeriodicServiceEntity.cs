using System;
using System.ComponentModel.DataAnnotations;

namespace CrvService.Common
{
    public class PeriodicServiceEntity
    {
        [Key] public string Name { get; set; }

        public bool Enabled { get; set; }

        public DateTime Added { get; set; }
        public DateTime Updated { get; set; }

        public DateTime LastRun { get; set; }

        public long LastRunDurationMilliseconds { get; set; }

        public string LastRunError { get; set; }

        public long Iteration { get; set; }

        public int PeriodMilliseconds { get; set; }


        public string Options { get; set; }

        public string ServiceType { get; set; }
    }
}