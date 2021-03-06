﻿using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Commands.ClientCommands.Base;

namespace CrvService.Shared.Logic.ClientCommandProcessors.Base
{
    public interface IClientCommandProcessor
    {
        void Process(IClientCommand clientCommand, IWorld world, IPlayer player);
    }
}