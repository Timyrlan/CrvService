using System;
using System.Linq;
using System.Text.Json.Serialization;
using CrvService.Shared.Contracts.Dto;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Logic;
using CrvService.Shared.Logic.ClientSide;
using CrvService.Shared.Logic.ClientSide.Buildings;
using CrvService.Shared.Logic.ClientSide.Cargos;
using CrvService.Shared.Logic.ClientSide.Server;
using Newtonsoft.Json;

namespace CrvService.Shared.ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Test4();
        }

        private static void Test4()
        {
            //var str =
            //    "{\"world\":{\"worldDate\":\"3000-01-01T00:00:00Z\",\"cities\":[{\"size\":1,\"x\":5.202,\"y\":1.344,\"name\":\"Moscow\",\"visible\":true,\"buildings\":[{\"cargos\":[{\"count\":1,\"guid\":\"5edf795d-4ee9-4272-bc8e-dc9ea3a9eb4a\",\"type\":\"FreshWater\"},{\"count\":1,\"guid\":\"334fb377-ee06-4b09-aad5-0f35ffa25db7\",\"type\":\"Salt\"}],\"guid\":\"0db8126e-29e9-453d-b84a-259e81e1b5bb\",\"type\":\"LivingHouse\"},{\"cargos\":[{\"count\":1,\"guid\":\"ff5e8cd0-2a57-43b3-b3b1-0d03e61b408b\",\"type\":\"SaltWater\"}],\"guid\":\"678f3318-0d5a-44ad-b850-aa19a83b251c\",\"type\":\"SaltEvaporationFactory\"}],\"guid\":\"28642d05-9a34-4186-83f9-ba564a18ec59\",\"type\":\"City\"},{\"size\":1,\"x\":6.039,\"y\":2.948,\"name\":\"Novgorod\",\"visible\":false,\"buildings\":[{\"cargos\":[{\"count\":1,\"guid\":\"fa9211c9-a3b1-48c4-a54e-114bf52d3aa2\",\"type\":\"FreshWater\"},{\"count\":1,\"guid\":\"62cce01d-b357-4280-b691-d89c357583db\",\"type\":\"Salt\"}],\"guid\":\"7cdf22f9-bbb2-4b8c-aedb-ba44af71b354\",\"type\":\"LivingHouse\"}],\"guid\":\"0410e443-cf6e-4d88-8289-284ed7fb40c3\",\"type\":\"City\"},{\"size\":1,\"x\":4.016,\"y\":3.741,\"name\":\"Kazan\",\"visible\":false,\"buildings\":[{\"cargos\":[{\"count\":1,\"guid\":\"1bea7197-4e8f-4625-816a-20fb9669d165\",\"type\":\"FreshWater\"},{\"count\":1,\"guid\":\"4abc4938-b8cc-4ae2-9a21-3aaf5e8fe091\",\"type\":\"Salt\"}],\"guid\":\"95ddd1ca-ed29-42fa-94f3-7de8b43a0d06\",\"type\":\"LivingHouse\"}],\"guid\":\"8e8a3b16-8481-47c9-bec8-431ac4f09b25\",\"type\":\"City\"},{\"size\":1,\"x\":6.577,\"y\":4.236,\"name\":\"Vladivistok\",\"visible\":false,\"buildings\":[{\"cargos\":[{\"count\":1,\"guid\":\"c11c65a2-f247-4ce1-9bf6-72771c37dbb8\",\"type\":\"FreshWater\"},{\"count\":1,\"guid\":\"0e2511e3-f6af-486b-b7ec-623c2f2b854a\",\"type\":\"Salt\"}],\"guid\":\"5291057f-8ae4-436e-9fdc-8151cc14e908\",\"type\":\"LivingHouse\"}],\"guid\":\"7b66e9a8-6d36-4b1c-88de-d51d0e0aec23\",\"type\":\"City\"},{\"size\":1,\"x\":7.463,\"y\":3.316,\"name\":\"Urengoy\",\"visible\":false,\"buildings\":[{\"cargos\":[{\"count\":1,\"guid\":\"035dac94-081e-4db9-9e25-48ccca716ebd\",\"type\":\"FreshWater\"},{\"count\":1,\"guid\":\"bde0c9cc-81fc-442a-934b-7a3e0246cc4b\",\"type\":\"Salt\"}],\"guid\":\"0bcdc613-b816-41d3-87c9-91daf3b6fd31\",\"type\":\"LivingHouse\"}],\"guid\":\"3b7ebdb7-a61d-4425-a58e-093b32e2eb4c\",\"type\":\"City\"},{\"size\":1,\"x\":6.107,\"y\":4.534,\"name\":\"Saratov\",\"visible\":false,\"buildings\":[{\"cargos\":[{\"count\":1,\"guid\":\"017e90b9-8c23-4e47-bd5f-64fa7671eac2\",\"type\":\"FreshWater\"},{\"count\":1,\"guid\":\"07396c81-bcad-4fd3-b47d-03d3ec0dafff\",\"type\":\"Salt\"}],\"guid\":\"e4ddf06b-7a05-4693-a9fd-4b176ebee5bc\",\"type\":\"LivingHouse\"}],\"guid\":\"648a9342-276b-4c70-a8e9-4c7ad923f78b\",\"type\":\"City\"},{\"size\":1,\"x\":7.041,\"y\":5.084,\"name\":\"Rostov\",\"visible\":false,\"buildings\":[{\"cargos\":[{\"count\":1,\"guid\":\"02fe1a0c-2b90-4ae7-b711-a5f1f1c4ba86\",\"type\":\"FreshWater\"},{\"count\":1,\"guid\":\"f89a843a-77de-4b33-a8cb-ee2e07342dd5\",\"type\":\"Salt\"}],\"guid\":\"e935a0de-8eff-498e-8293-d17f7becf7c2\",\"type\":\"LivingHouse\"}],\"guid\":\"ecfb1b7b-2bc3-4ed3-8f63-96a8378681ea\",\"type\":\"City\"},{\"size\":1,\"x\":5.545,\"y\":3.92,\"name\":\"Izhevsk\",\"visible\":false,\"buildings\":[{\"cargos\":[{\"count\":1,\"guid\":\"498d5983-50e6-4777-8570-c9c524046ea4\",\"type\":\"FreshWater\"},{\"count\":1,\"guid\":\"d5a7f39c-24d0-48cb-9e80-ea82099f9eeb\",\"type\":\"Salt\"}],\"guid\":\"fcccec9c-768a-4771-82ab-b31c64d734e5\",\"type\":\"LivingHouse\"}],\"guid\":\"e7ba8884-b4d6-4ab8-85ea-db27fc035653\",\"type\":\"City\"},{\"size\":1,\"x\":8.551,\"y\":1.37,\"name\":\"Sestoretsk\",\"visible\":false,\"buildings\":[{\"cargos\":[{\"count\":1,\"guid\":\"40771222-5a7b-4bb5-a589-fdc93774eca3\",\"type\":\"FreshWater\"},{\"count\":1,\"guid\":\"16ce79d5-e354-4a93-aaf9-7cb09c5738ea\",\"type\":\"Salt\"}],\"guid\":\"a877f2fa-2fca-4249-99b2-04eee1495f5b\",\"type\":\"LivingHouse\"}],\"guid\":\"251e8405-a756-405f-bc09-0acfc31bf0e9\",\"type\":\"City\"},{\"size\":1,\"x\":4.414,\"y\":1.897,\"name\":\"Kiev\",\"visible\":false,\"buildings\":[{\"cargos\":[{\"count\":1,\"guid\":\"d2a9b1ff-eccd-47a8-b696-054d3398ace8\",\"type\":\"FreshWater\"},{\"count\":1,\"guid\":\"1d773dac-bf55-4631-a07c-d7b1e69b739a\",\"type\":\"Salt\"}],\"guid\":\"689012a2-deb1-4e0d-b7a0-daf28b91e8dc\",\"type\":\"LivingHouse\"}],\"guid\":\"f85f8514-d993-4fe2-87d9-5f240ddbf213\",\"type\":\"City\"}],\"guid\":\"6e23709e-5bf4-43b1-b606-f09be45d69bf\",\"type\":\"World\"},\"player\":{\"visibleCities\":[\"28642d05-9a34-4186-83f9-ba564a18ec59\"],\"x\":5.202,\"y\":1.344,\"isMoving\":false,\"moveToX\":0,\"moveToY\":0,\"guid\":\"808ef344-357c-4376-996f-8bc7d75b8d21\",\"type\":\"Player\"},\"status\":{\"code\":200,\"errorMessage\":null}}";
            //var obj = JsonConvert.DeserializeObject<ProcessWorldResponse>(str);

            var obj = new ProcessWorldResponse()
            {
                World = new WorldDto()
                {
                    Guid = "qqq"
                }
            };

            var a = JsonConvert.SerializeObject(obj);
        }

        //private static void Test3()
        //{
        //    var newInstanceFactory = new NewInstanceFactoryClientSide();
        //    var processorsProvider = new ProcessorsProvider(newInstanceFactory);
        //    var newWorldGenerator = new NewWorldGenerator(newInstanceFactory);
        //    ICaravanServer caravanServer = new CaravanServerClientSide(processorsProvider, newInstanceFactory, newWorldGenerator);

        //    var response = caravanServer.ProcessWorld(new ProcessWorldRequestClientSideEntity());
        //    var responseWorld = response.World;
        //    var responsePlayer = response.Player;
        //    var city = responseWorld.Cities.Collection.First();

        //    CheckEquals(1, city.Buildings.Collection.First(c => c.Type == "LivingHouse").Cargos.Collection.Single(c => c.Type == "FreshWater").Count);

        //    response = caravanServer.ProcessWorld(new ProcessWorldRequestClientSideEntity {WorldGuid = responseWorld.Guid, Player = responsePlayer});
        //    responseWorld = response.World;
        //    responsePlayer = response.Player;
        //    city = responseWorld.Cities.Collection.First();
        //    CheckEquals(1 - 0.01m, city.Buildings.Collection.First(c => c.Type == "LivingHouse").Cargos.Collection.Single(c => c.Type == "FreshWater").Count);
        //}


        //private static void Test2()
        //{
        //    var newInstanceFactory = new NewInstanceFactoryClientSide();
        //    var processorsProvider = new ProcessorsProvider(newInstanceFactory);
        //    var newWorldGenerator = new NewWorldGenerator(newInstanceFactory);
        //    ICaravanServer caravanServer = new CaravanServerClientSide(processorsProvider, newInstanceFactory, newWorldGenerator);

        //    var world = GetPlayer();
        //    caravanServer.LoadWorld(world);
        //    var response = caravanServer.ProcessWorld(new ProcessWorldRequest {WorldGuid = world.Guid});

        //    var responseWorld = ToClientSideMapper.Map(response.World);
        //    var responsePlayer = ToClientSideMapper.Map(response.Player);

        //    var city = responseWorld.Cities.Collection.First();

        //    CheckEquals("SomeCity", city.Name);
        //    CheckEquals(1 - 0.01m, city.Buildings.Collection.First(c => c.Type == "LivingHouse").Cargos.Collection.Single(c => c.Type == "FreshWater").Count);
        //}

        //private static void Test1()
        //{
        //    var newInstanceFactory = new NewInstanceFactoryClientSide();
        //    var processorsProvider = new ProcessorsProvider(newInstanceFactory);

        //    var world = GetPlayer();

        //    processorsProvider.Process(world);
        //}

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