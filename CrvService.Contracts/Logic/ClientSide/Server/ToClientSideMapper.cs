using System;
using System.Collections.Generic;
using System.Linq;
using CrvService.Shared.Contracts.Dto;
using CrvService.Shared.Contracts.Dto.Buildings;
using CrvService.Shared.Contracts.Dto.Cargos;
using CrvService.Shared.Contracts.Dto.ClientCommands.Base;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Buildings.Base;
using CrvService.Shared.Contracts.Entities.Cargos.Base;
using CrvService.Shared.Contracts.Entities.ClientCommands;
using CrvService.Shared.Contracts.Entities.ClientCommands.Base;
using CrvService.Shared.Logic.ClientSide.Buildings;
using CrvService.Shared.Logic.ClientSide.Cargos;
using CrvService.Shared.Logic.ClientSide.ClientCommands;

// ReSharper disable UseObjectOrCollectionInitializer

namespace CrvService.Shared.Logic.ClientSide.Server
{
    public static class ToClientSideMapper
    {
        public static IProcessWorldRequest Map(ProcessWorldRequest c)
        {
            var result = new ProcessWorldRequestClientSideEntity();
            result.WorldGuid = c.WorldGuid;
            result.Player = Map(c.Player);
            result.ClientCommands = Map(c.ClientCommands);
            return result;
        }

        public static IGetNewWorldRequest Map(GetNewWorldRequest c)
        {
            var result = new GetNewWorldRequestClientSideEntity();
            result.UserGuid = c.UserGuid;
            return result;
        }

        public static IProcessWorldResponse Map(ProcessWorldResponse c)
        {
            var result = new ProcessWorldResponseClientSideEntity();
            result.Player = Map(c.Player);
            result.World = Map(c.World);
            return result;
        }

        private static IPlayer Map(PlayerDto c)
        {
            if (c == null) return null;
            var result = new PlayerClientSideEntity {Type = c.Type, Guid = c.Guid};

            result.VisibleCities = c.VisibleCities;
            result.X = c.X;
            result.Y = c.Y;
            result.IsMoving = c.IsMoving;
            result.MoveToX = c.MoveToX;
            result.MoveToY = c.MoveToY;

            return result;
        }

        private static IClientCommand[] Map(ClientCommandDto[] clientCommandsDto)
        {
            var result = new List<IClientCommand>();

            if (clientCommandsDto != null && clientCommandsDto.Any())
                foreach (var c in clientCommandsDto)
                    if (c.Type == H.Get<IMovePlayerClientCommand>())
                        result.Add(MapMovePlayerClientCommand(c));
                    else if (c.Type == H.Get<IPing>())
                        result.Add(MapPingClientCommand(c));
                    else
                        throw new Exception($"Unexpected client command type='{c.Type}'");

            return result.ToArray();
        }

        private static IMovePlayerClientCommand MapMovePlayerClientCommand(ClientCommandDto c)
        {
            var result = new MovePlayerClientCommandClientSideEntity {Type = c.Type, Guid = c.Guid};
            result.ToX = c.ToX;
            result.ToY = c.ToY;
            return result;
        }


        private static IPing MapPingClientCommand(ClientCommandDto c)
        {
            var result = new PingClientSideEntity {Type = c.Type, Guid = c.Guid};
            return result;
        }

        private static IWorld Map(WorldDto c)
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