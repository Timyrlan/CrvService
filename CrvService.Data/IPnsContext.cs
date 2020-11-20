using System;
using System.Threading.Tasks;
using CrvService.Data.Entities;
using CrvService.Data.Entities.Buildings;
using CrvService.Data.Entities.Buildings.Base;
using CrvService.Data.Entities.Cargos;
using CrvService.Data.Entities.Cargos.Base;
using CrvService.Data.Entities.Commands.ClientCommands.Base;
using CrvService.Data.Entities.Commands.ServerCommands.Base;
using Microsoft.EntityFrameworkCore;

namespace CrvService.Data
{
    public interface ICrvServiceContext : IDisposable
    {
        DbSet<BuildingEntity> Buildings { get; set; }
        DbSet<LivingHouseEntity> LivingHouses { get; set; }
        DbSet<SaltEvaporationFactoryEntity> SaltEvaporationFactories { get; set; }
        DbSet<CargoEntity> Cargos { get; set; }
        DbSet<FreshWaterEntity> FreshWater { get; set; }
        DbSet<SaltEntity> Salt { get; set; }
        DbSet<SaltWaterEntity> SaltWater { get; set; }

        DbSet<CityEntity> Cities { get; set; }

        DbSet<WorldEntity> Worlds { get; set; }

        DbSet<PlayerEntity> Players { get; set; }

        DbSet<ClientCommandEntity> ClientCommands { get; set; }

        DbSet<ServerCommandEntity> ServerCommands { get; set; }
        DbSet<EnterCityServerCommandEntity> EnterCityServerCommands { get; set; }
        Task DeleteExecutedClientCommands();

        void Migrate();

        Task SaveAsync();
    }
}