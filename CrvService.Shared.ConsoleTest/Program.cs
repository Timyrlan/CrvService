using System;
using System.Linq;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Logic;
using CrvService.Shared.Logic.ClientSide;
using CrvService.Shared.Logic.ClientSide.Buildings;
using CrvService.Shared.Logic.ClientSide.Cargos;
using CrvService.Shared.Logic.ClientSide.Server;

namespace CrvService.Shared.ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Test3();
        }

        private static void Test3()
        {
            var newInstanceFactory = new NewInstanceFactoryClientSide();
            var processorsProvider = new ProcessorsProvider(newInstanceFactory);
            var newWorldGenerator = new NewWorldGenerator(newInstanceFactory);
            ICaravanServer caravanServer = new CaravanServerClientSide(processorsProvider, newInstanceFactory, newWorldGenerator);


            var response = caravanServer.ProcessWorld(string.Empty, string.Empty);
            var responseWorld = ToClientSideMapper.Map(response.World);
            var responsePlayer = ToClientSideMapper.Map(response.Player);
            var city = responseWorld.Cities.Collection.First();
            
            CheckEquals(1, city.Buildings.Collection.First(c => c.Type == "LivingHouse").Cargos.Collection.Single(c => c.Type == "FreshWater").Count);

            response = caravanServer.ProcessWorld(responseWorld.Guid, responsePlayer.Guid);
            responseWorld = ToClientSideMapper.Map(response.World);
            responsePlayer = ToClientSideMapper.Map(response.Player);
            city = responseWorld.Cities.Collection.First();
            CheckEquals(1 - 0.01m, city.Buildings.Collection.First(c => c.Type == "LivingHouse").Cargos.Collection.Single(c => c.Type == "FreshWater").Count);
        }


        private static void Test2()
        {
            var newInstanceFactory = new NewInstanceFactoryClientSide();
            var processorsProvider = new ProcessorsProvider(newInstanceFactory);
            var newWorldGenerator = new NewWorldGenerator(newInstanceFactory);
            ICaravanServer caravanServer = new CaravanServerClientSide(processorsProvider, newInstanceFactory, newWorldGenerator);

            var world = GetWorld();
            caravanServer.LoadWorld(world);
            var response = caravanServer.ProcessWorld(world.Guid, string.Empty);

            var responseWorld = ToClientSideMapper.Map(response.World);
            var responsePlayer = ToClientSideMapper.Map(response.Player);

            var city = responseWorld.Cities.Collection.First();

            CheckEquals("SomeCity", city.Name);
            CheckEquals(1 - 0.01m, city.Buildings.Collection.First(c => c.Type == "LivingHouse").Cargos.Collection.Single(c => c.Type == "FreshWater").Count);
        }

        private static void Test1()
        {
            var newInstanceFactory = new NewInstanceFactoryClientSide();
            var processorsProvider = new ProcessorsProvider(newInstanceFactory);

            var world = GetWorld();

            processorsProvider.Process(world);
        }

        private static void CheckEquals<T>(T expected, T actual)
        {
            if (!expected.Equals(actual)) throw new Exception($"Expected='{expected}', actual='{actual}'");
        }


        private static IWorld GetWorld()
        {
            var world = new WorldClientSideEntity();
            var city = new CityClientSideEntity {Name = "SomeCity"};
            world.Cities.Add(city);

            var livingHouse = new LivingHouseClientSideEntity();
            livingHouse.Cargos.Add(new FreshWaterClientSideEntity {Count = 1m});
            livingHouse.Cargos.Add(new SaltClientSideEntity {Count = 1m});
            city.Buildings.Add(livingHouse);

            var saltEvaporationFactory = new SaltEvaporationFactoryClientSideEntity();
            saltEvaporationFactory.Cargos.Add(new SaltWaterClientSideEntity {Count = 1});
            city.Buildings.Add(saltEvaporationFactory);
            return world;
        }
    }
}