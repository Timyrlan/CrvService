using System;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.Commands.ClientCommands.Base;

namespace CrvService.Shared.Logic.ClientCommandProcessors.Base
{
    public abstract class ClientCommandProcessorBase : IClientCommandProcessor
    {
        protected ClientCommandProcessorBase(IProcessorsProvider processorsProvider)
        {
            ProcessorsProvider = processorsProvider;
        }

        protected IProcessorsProvider ProcessorsProvider { get; }

        public virtual void Process(IClientCommand clientCommand, IWorld world, IPlayer player)
        {
            clientCommand.Processed = true;
            clientCommand.ProcessDateTime = DateTime.UtcNow;
        }
    }
}