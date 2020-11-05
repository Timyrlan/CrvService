using CrvService.Shared.Logic.ClientCommandProcessors.Base;

namespace CrvService.Shared.Logic.ClientCommandProcessors
{
    public class PingCommandProcessor : ClientCommandProcessorBase
    {
        public PingCommandProcessor(IProcessorsProvider processorsProvider) : base(processorsProvider)
        {
        }
    }
}