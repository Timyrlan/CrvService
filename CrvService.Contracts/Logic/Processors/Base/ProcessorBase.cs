namespace CrvService.Shared.Logic.Processors.Base
{
    public abstract class ProcessorBase : IProcessor
    {
        protected ProcessorBase(IProcessorsProvider processorsProvider, INewInstanceFactory newInstanceFactory)
        {
            ProcessorsProvider = processorsProvider;
            NewInstanceFactory = newInstanceFactory;
        }

        protected IProcessorsProvider ProcessorsProvider { get; }
        protected INewInstanceFactory NewInstanceFactory { get; }

        public virtual void Process(object entity)
        {
        }
    }
}