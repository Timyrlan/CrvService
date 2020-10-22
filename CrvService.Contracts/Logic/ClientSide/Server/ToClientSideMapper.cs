using System;
using CrvService.Shared.Contracts.Dto;
using CrvService.Shared.Contracts.Dto.Buildings;
using CrvService.Shared.Contracts.Dto.Cargos;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Buildings;
using CrvService.Shared.Contracts.Entities.Cargos;
using CrvService.Shared.Logic.ClientSide.Buildings;
using CrvService.Shared.Logic.ClientSide.Cargos;

// ReSharper disable UseObjectOrCollectionInitializer

namespace CrvService.Shared.Logic.ClientSide.Server
{
    public static class ToClientSideMapper
    {
        public static IWorld Map(WorldDto c)
        {
            var result = new WorldClientSideEntity {Type = c.Type, Guid = c.Guid};

            result.WorldDate = c.WorldDate;

            foreach (var cityDto in c.Cities) result.Cities.Add(Map(cityDto));


            return result;
        }

        private static ICity Map(CityDto c)
        {
            var result = new CityClientSideEntity {Type = c.Type, Guid = c.Guid};

            result.Size = c.Size;
            result.X = c.X;
            result.Y = c.Y;
            result.Name = c.Name;

            foreach (var buildingDto in c.Buildings) result.Buildings.Add(Map(buildingDto));


            return result;
        }

        private static IBuilding Map(BuildingDto c)
        {
            IBuilding result;

            if (c.Type == "LivingHouse")
                result = new LivingHouseClientSideEntity {Type = c.Type, Guid = c.Guid};
            else if (c.Type == "SaltEvaporationFactory")
                result = new SaltEvaporationFactoryClientSideEntity {Type = c.Type, Guid = c.Guid};
            else
                throw new Exception($"Unexpected building type='{c.Type}'");


            foreach (var cargoDto in c.Cargos) result.Cargos.Add(Map(cargoDto));

            return result;
        }

        private static ICargo Map(CargoDto c)
        {
            ICargo result;


            if (c.Type == "FreshWater")
                result = new FreshWaterClientSideEntity {Type = c.Type, Guid = c.Guid};
            else if (c.Type == "Salt")
                result = new SaltClientSideEntity {Type = c.Type, Guid = c.Guid};
            else if (c.Type == "SaltWater")
                result = new FreshWaterClientSideEntity {Type = c.Type, Guid = c.Guid};
            else
                throw new Exception($"Unexpected cargo type='{c.Type}'");

            result.Count = c.Count;

            return result;
        }
    }
}