using CrvService.Shared.Logic.ClientSide;
using CrvService.Shared.Logic.ClientSide.Buildings;
using CrvService.Shared.Logic.ClientSide.Cargos;
using CrvService.Shared.Logic.ClientSide.Server;
using NUnit.Framework;

namespace CrvService.Shared.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var worldRepository = new WorldRepositoryClientSide();
            var playerRepository = new PlayerRepositoryClientSide();
            var newInstanceFactory = new NewInstanceFactoryClientSide(worldRepository, playerRepository);
            var processorsProvider = new ProcessorsProvider(newInstanceFactory);

            var world = new WorldClientSideEntity();
            var city = new CityClientSideEntity();
            world.Cities.Add(city);

            var livingHouse = new LivingHouseClientSideEntity();
            livingHouse.Cargos.Add(new FreshWaterClientSideEntity {Count = 1m});
            livingHouse.Cargos.Add(new SaltClientSideEntity {Count = 1m});
            city.Buildings.Add(livingHouse);

            var saltEvaporationFactory = new SaltEvaporationFactoryClientSideEntity();
            saltEvaporationFactory.Cargos.Add(new SaltWaterClientSideEntity {Count = 1});

            processorsProvider.Process(world);
        }
    }
}