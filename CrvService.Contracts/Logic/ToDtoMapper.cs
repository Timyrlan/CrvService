using System;
using System.Collections.Generic;
using System.Linq;
using CrvService.Shared.Contracts.Dto;
using CrvService.Shared.Contracts.Dto.Buildings;
using CrvService.Shared.Contracts.Dto.Cargos;
using CrvService.Shared.Contracts.Dto.ClientCommands;
using CrvService.Shared.Contracts.Dto.ClientCommands.Base;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Buildings.Base;
using CrvService.Shared.Contracts.Entities.Cargos.Base;
using CrvService.Shared.Contracts.Entities.ClientCommands;
using CrvService.Shared.Contracts.Entities.ClientCommands.Base;
using CrvService.Shared.Logic.ClientSide;

// ReSharper disable UseObjectOrCollectionInitializer

namespace CrvService.Shared.Logic
{
    public static class ToDtoMapper
    {
        public static ProcessWorldResponse Map(IProcessWorldResponse c)
        {
            var result = new ProcessWorldResponse();

            result.Player = Map(c.Player);
            result.World = Map(c.World, c.Player);

            return result;
        }

        public static ProcessWorldRequest Map(IProcessWorldRequest c)
        {
            var result = new ProcessWorldRequest();

            result.WorldGuid = c.WorldGuid;
            result.Player = Map(c.Player);
            result.ClientCommands = Map(c.ClientCommands);

            return result;
        }

        public static PlayerDto Map(IPlayer c)
        {
            if (c == null) return null;

            var result = new PlayerDto {Type = c.Type, Guid = c.Guid};

            result.VisibleCities = c.VisibleCities;
            result.X = c.X;
            result.Y = c.Y;
            result.IsMoving = c.IsMoving;
            result.MoveToX = c.MoveToX;
            result.MoveToY = c.MoveToY;

            return result;
        }

        public static WorldDto Map(IWorld c, IPlayer player)
        {
            if (c == null) return null;
            var result = new WorldDto {Type = c.Type, Guid = c.Guid};

            result.WorldDate = c.WorldDate;
            result.Cities = c.Cities.Collection.Select(cc => Map(cc, player?.VisibleCities)).ToArray();

            return result;
        }

        public static ClientCommandDto[] Map(IClientCommand[] clientCommands)
        {
            var result = new List<ClientCommandDto>();

            if (clientCommands != null && clientCommands.Any())
                foreach (var clientCommand in clientCommands)
                    if (clientCommand.Type == Name.Get<IMovePlayerClientCommand>())
                        result.Add(Map(Cast<IMovePlayerClientCommand>(clientCommand)));
                    else
                        throw new Exception($"Unexpexted client command type='{clientCommand.Type}'");

            return result.ToArray();
        }

        private static ClientCommandDto Map(IMovePlayerClientCommand c)
        {
            var result = new MovePlayerClientCommandDto {Type = c.Type, Guid = c.Guid};
            result.ToX = c.ToX;
            result.ToY = c.ToY;
            return result;
        }

        private static CityDto Map(ICity c, string[] visibleCities)
        {
            var result = new CityDto {Type = c.Type, Guid = c.Guid};

            result.Size = c.Size;
            result.X = c.X;
            result.Y = c.Y;
            result.Name = c.Name;
            result.Visible = visibleCities?.Contains(c.Guid) ?? false;
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

        private static T Cast<T>(object c) where T : class
        {
            var result = c as T;
            if (result == null) throw new Exception($"Argument type='{c?.GetType().Name}' not castble to '{typeof(T).Name}'");
            return result;
        }
    }
}