namespace CrvService.Data
{
    public interface ICrvServiceContextFactory
    {
        ICrvServiceContext GetContext(int? timeoutSeconds = null);
    }
}