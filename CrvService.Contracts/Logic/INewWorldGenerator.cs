using System;
using CrvService.Shared.Contracts.Entities;

namespace CrvService.Shared.Logic
{
    public interface INewWorldGenerator
    {
        Tuple<IWorld, IPlayer> GenerateWorld(string userGuid);
    }
}