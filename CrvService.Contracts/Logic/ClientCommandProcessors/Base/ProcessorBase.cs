using System;
using CrvService.Shared.Contracts.Entities;
using CrvService.Shared.Contracts.Entities.ClientCommands.Base;

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
        }


        protected T Cast<T>(object c) where T : class
        {
            var result = c as T;
            if (result == null) throw new Exception($"Argument type='{c?.GetType().Name}' not castble to '{typeof(T).Name}'");
            return result;
        }
    }
}