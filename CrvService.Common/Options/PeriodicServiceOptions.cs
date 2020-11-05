namespace CrvService.Common.Options
{
    public abstract class PeriodicServiceOptions : ServiceOptions
    {
        public virtual int PeriodMilliseconds { get; set; } = 1000;

        public virtual string ServiceType { get; set; } = "NoType";
    }
}