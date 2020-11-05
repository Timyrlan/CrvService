using System;
using CrvService.Data.Entities;
using CrvService.Shared.Contracts.Entities.ClientCommands;
using CrvService.Shared.Contracts.Entities.ClientCommands.Base;
using CrvService.Shared.Logic;

namespace CrvService.ServerSide
{
    public static class ClientCommandMapper
    {
        public static void Fill(ClientCommandEntity c, WorldEntity world, PlayerEntity player)
        {
            c.WorldId = world.Id;
            c.WorldGuid = world.Guid;
            c.PlayerId = player.Id;
            c.PlayerGuid = player.Guid;
            c.CreationDateTime = DateTime.UtcNow;
        }

        private static MovePlayerClientCommandEntity Map(IMovePlayerClientCommand c, WorldEntity world, PlayerEntity player)
        {
            var result = new MovePlayerClientCommandEntity();
            Fill(result, world, player);
            result.ToX = c.ToX;
            result.ToY = c.ToY;
            return result;
        }

        private static PingEntity Map(IPing c, WorldEntity world, PlayerEntity player)
        {
            var result = new PingEntity();
            Fill(result, world, player);
            return result;
        }

        public static ClientCommandEntity Map(IClientCommand c, WorldEntity world, PlayerEntity player)
        {
            if (c.Type == H.Get<IPing>()) return Map(c as IPing, world, player);
            if (c.Type == H.Get<IMovePlayerClientCommand>()) return Map(c as IMovePlayerClientCommand, world, player);

            throw new Exception($"Unexpected client command type='{c.Type}'");
        }
    }
}