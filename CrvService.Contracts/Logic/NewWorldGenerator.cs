using System;
using System.Collections.Generic;
using System.Linq;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Buildings;
using CrvService.Shared.Contracts.Entities.Cargos;
using CrvService.Shared.Logic.ClientSide;

namespace CrvService.Shared.Logic
{
    public class NewWorldGenerator : INewWorldGenerator
    {
        public const float CameraWidth = 20;
        public const float CameraHeight = 10;
        public const float CameraBorder = 2;
        public const float CityUnDensity = 1;
        public const float CoordinateAccuracy = 0.01f;
        public const int InitializeCityCount = 7;

        public NewWorldGenerator(INewInstanceFactory newInstanceFactory, IPlayerRepository playerRepository)
        {
            NewInstanceFactory = newInstanceFactory;
            PlayerRepository = playerRepository;
        }

        //private void UpdateVisibleCities()
        //{
        //    foreach (var city in Cities.Where(c => !c.Visible))
        //        if (Mathf.Abs(city.X - PlayerController.transform.position.x) < 1 + city.Size / 2 && Mathf.Abs(city.Y - PlayerController.transform.position.y) < 1 + city.Size / 2)
        //        {
        //            city.SetVisible();
        //            WriteLog($"You find city {city.Name}");
        //        }
        //}

        private Random Random { get; } = new Random();

        private string[] CityNames { get; } = {"Moscow", "Novgorod", "Kazan", "Vladivistok", "Urengoy", "Saratov", "Rostov", "Izhevsk", "Sestoretsk", "Kiev"};

        private INewInstanceFactory NewInstanceFactory { get; }

        private IPlayerRepository PlayerRepository { get; }

        public Tuple<IWorld, IPlayer> GenerateWorld(IPlayer player)
        {
            if (player == null)
                player = NewInstanceFactory.GetNewInstance<IPlayer>();
            else
                player = PlayerRepository.GetPlayer(player.Guid) ?? NewInstanceFactory.GetNewInstance<IPlayer>();

            var localCityNames = CityNames.Select(c => c).ToArray();

            var world = NewInstanceFactory.GetNewInstance<IWorld>();
            world.WorldDate = new DateTime(3000, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            for (var i = 0; i < InitializeCityCount; i++)
            {
                var cooridnates = GenerateInitializedCityVectorInScreenN(1, 0, world.Cities.Collection);

                if (cooridnates != null)
                {
                    Tuple<ICity, string[]> city = null;
                    //if (i == 0)
                    //    city = AddCity(new Tuple<float, float>(0, 0), localCityNames);
                    //else if (i == 1)
                    //    city = AddCity(new Tuple<float, float>(10, 5), localCityNames);
                    //else if (i == 2)
                    //    city = AddCity(new Tuple<float, float>(-10, -5), localCityNames);
                    //else if (i == 3)
                    //    city = AddCity(new Tuple<float, float>(10, -5), localCityNames);
                    //else if (i == 4)
                    //    city = AddCity(new Tuple<float, float>(-10, 5), localCityNames);
                    //else
                        city = AddCity(cooridnates, localCityNames);
                    //var city = AddCity(cooridnates, localCityNames);
                    world.Cities.Add(city.Item1);
                    //localCityNames = city.Item2;
                }
            }

            var firstCity = world.Cities.Collection.First();

            player.X = firstCity.X;
            player.Y = firstCity.Y;
            player.VisibleCities = new[] {firstCity.Guid};

            var saltEvaporationFactory = NewInstanceFactory.GetNewInstance<ISaltEvaporationFactory>();
            firstCity.Buildings.Add(saltEvaporationFactory);
            saltEvaporationFactory.Cargos.Add(NewInstanceFactory.GetCargoNewInstance<ISaltWater>(1));

            return new Tuple<IWorld, IPlayer>(world, player);
        }

        private Tuple<ICity, string[]> AddCity(Tuple<float, float> cooridnates, string[] localCityNames)
        {
            var city = NewInstanceFactory.GetNewInstance<ICity>();
            city.Name = localCityNames.First();
            city.Size = 1;
            city.X = cooridnates.Item1;
            city.Y = cooridnates.Item2;

            localCityNames = localCityNames.Where(c => !string.Equals(c, city.Name, StringComparison.InvariantCultureIgnoreCase)).ToArray();

            FillCityByHouses(city);

            return new Tuple<ICity, string[]>(city, localCityNames);
        }


        private void FillCityByHouses(ICity city)
        {
            var countAll = Math.Floor(city.Size);
            var countToAdd = countAll - city.Buildings.Collection.Count(c => c.Type == Name.Get<ILivingHouse>());
            countToAdd = countToAdd > 0 ? countToAdd : 0;
            for (var i = 0; i < countToAdd; i++) city.Buildings.Add(AddLivingHouse());
        }

        private ILivingHouse AddLivingHouse()
        {
            var livingHouse = NewInstanceFactory.GetNewInstance<ILivingHouse>();

            livingHouse.Cargos.Add(NewInstanceFactory.GetCargoNewInstance<IFreshWater>(1));
            livingHouse.Cargos.Add(NewInstanceFactory.GetCargoNewInstance<ISalt>(1));

            return livingHouse;
        }

        private Tuple<float, float> GenerateInitializedCityVectorInScreenN(float size, int deep, IEnumerable<ICity> cities)
        {
            if (deep >= 20)
                return null;

            var accuracy = 1000;

            var width = (CameraWidth - size * 3 / 4)  * accuracy;
            var height = (CameraHeight - size * 3 / 4) * accuracy;


            // ReSharper disable once PossibleLossOfFraction
            var cityX = Random.Next((int) Math.Floor(width)) - width / 2;
            // ReSharper disable once PossibleLossOfFraction
            var cityY = Random.Next((int) Math.Floor(height)) - height / 2;


            // ReSharper disable once PossibleMultipleEnumeration
            foreach (var city in cities)
            {
                var x = Math.Abs(city.X * accuracy - cityX);
                var y = Math.Abs(city.Y * accuracy - cityY);
                var distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                var minDistance = (city.Size/2 + size/2 + CityUnDensity) * accuracy;

                if (distance < minDistance)
                    // ReSharper disable once PossibleMultipleEnumeration
                    return GenerateInitializedCityVectorInScreenN(size, deep + 1, cities);
            }


            return new Tuple<float, float>(cityX / accuracy, cityY / accuracy);
        }
    }
}