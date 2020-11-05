using Microsoft.EntityFrameworkCore.Design;

namespace CrvService.Data
{
    public class CrvServiceContextFactoryFactory : IDesignTimeDbContextFactory<CrvServiceContext>
    {
        public CrvServiceContext CreateDbContext(string[] args)
        {
            return new CrvServiceContext("server=127.0.0.1;database=CrvService-local;user=root;password=123qwe;SslMode=none;AllowPublicKeyRetrieval=True;", null, new OptionsStub<Logging.Logging>(new Logging.Logging()));
        }
    }
}