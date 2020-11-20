using System.Collections.Generic;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Commands.ClientCommands.Base;
using CrvService.Shared.Logic.ClientCommandProcessors.Base;
using CrvService.Shared.Logic.Processors.Base;

namespace CrvService.Shared.Logic
{
    public interface IProcessorsProvider
    {
        Dictionary<string, IProcessor> Processors { get; }

        Dictionary<string, IClientCommandProcessor> ClientCommandProcessors { get; }

        void Process(object entity);

        void ProcessClientCommand(IClientCommand clientCommand, IWorld world, IPlayer player);
    }
}