using System.Diagnostics;
using System.Threading.Tasks;
using CrvService.Data.Entities;
using CrvService.Data.Entities.Buildings;
using CrvService.Data.Entities.Buildings.Base;
using CrvService.Data.Entities.Cargos;
using CrvService.Data.Entities.Cargos.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CrvService.Data
{
    public class CrvServiceContext : DbContext, ICrvServiceContext
    {
        public CrvServiceContext(string connectionString, ILogger<CrvServiceContext> logger, IOptions<Logging.Logging> logging)
        {
            ConnectionString = connectionString;
            Logger = logger;
            Logging = logging;
        }

        private string ConnectionString { get; }
        private ILogger<CrvServiceContext> Logger { get; }
        private IOptions<Logging.Logging> Logging { get; }

        public DbSet<ClientCommandEntity> ClientCommands { get; set; }

        public DbSet<BuildingEntity> Buildings { get; set; }
        public DbSet<LivingHouseEntity> LivingHouses { get; set; }
        public DbSet<SaltEvaporationFactoryEntity> SaltEvaporationFactories { get; set; }
        public DbSet<CargoEntity> Cargos { get; set; }
        public DbSet<FreshWaterEntity> FreshWater { get; set; }
        public DbSet<SaltEntity> Salt { get; set; }
        public DbSet<SaltWaterEntity> SaltWater { get; set; }

        public DbSet<CityEntity> Cities { get; set; }

        public DbSet<WorldEntity> Worlds { get; set; }

        public DbSet<PlayerEntity> Players { get; set; }

        public async Task SaveAsync()
        {
            await SaveChangesAsync();
        }

        public void Migrate()
        {
            var sw = Stopwatch.StartNew();
            Logger.LogInformation("Start DB migration");
            Database.Migrate();
            Logger.LogInformation($"Finish DB migration at {sw.ElapsedMilliseconds}ms");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}