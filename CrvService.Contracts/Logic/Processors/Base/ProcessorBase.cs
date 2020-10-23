using System;

namespace CrvService.Shared.Logic.Processors.Base
{
    public abstract class ProcessorBase : IProcessor
    {
        protected ProcessorBase(IProcessorsProvider processorsProvider)
        {
            ProcessorsProvider = processorsProvider;
        }

        protected IProcessorsProvider ProcessorsProvider { get; }

        public virtual void Process(object entity)
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