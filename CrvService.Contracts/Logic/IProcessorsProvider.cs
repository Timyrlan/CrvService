using System.Collections.Generic;
using CrvService.Shared.Logic.Processors.Base;

namespace CrvService.Shared.Logic
{
    public interface IProcessorsProvider
    {
        Dictionary<string, IProcessor> Processors { get; }

        void Process(object entity);
    }
}