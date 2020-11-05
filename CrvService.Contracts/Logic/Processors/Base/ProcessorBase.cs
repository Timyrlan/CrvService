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
    }
}