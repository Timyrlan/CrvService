using System;
using System.Linq;
using CrvService.Shared.Contracts.Dto;
using CrvService.Shared.Contracts.Dto.Buildings;
using CrvService.Shared.Contracts.Dto.Cargos;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Buildings;
using CrvService.Shared.Contracts.Entities.Cargos;

// ReSharper disable UseObjectOrCollectionInitializer

namespace CrvService.Shared.Logic
{
    public static class ToDtoMapper
    {
        public static WorldDto Map(IWorld c)
        {
            var result = new WorldDto {Type = c.Type, Guid = c.Guid};

            result.WorldDate = c.WorldDate;
            result.Cities = c.Cities.Collection.Select(Map).ToArray();

            return result;
        }

        private static CityDto Map(ICity c)
        {
            var result = new CityDto {Type = c.Type, Guid = c.Guid};

            result.Size = c.Size;
            result.X = c.X;
            result.Y = c.Y;
            result.Name = c.Name;
            result.Buildings = c.Buildings.Collection.Select(Map).ToArray();

            return result;
        }

        private static BuildingDto Map(IBuilding c)
        {
            var result = new BuildingDto {Type = c.Type, Guid = c.Guid};

            result.Cargos = c.Cargos.Collection.Select(Map).ToArray();

            if (c.Type == "LivingHouse")
            {
                //
            }
            else if (c.Type == "SaltEvaporationFactory")
            {
                //
            }
            else
            {
                throw new Exception($"Unexpected building type='{c.Type}'");
            }

            return result;
        }

        private static CargoDto Map(ICargo c)
        {
            var result = new CargoDto {Type = c.Type, Guid = c.Guid};

            result.Count = c.Count;

            if (c.Type == "FreshWater")
            {
                //
            }
            else if (c.Type == "Salt")
            {
                //
            }
            else if (c.Type == "SaltWater")
            {
                //
            }
            else
            {
                throw new Exception($"Unexpected cargo type='{c.Type}'");
            }

            return result;
        }
    }
}