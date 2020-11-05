using System;
using System.Diagnostics;
using System.Threading;
using CrvService.Logging;
using Microsoft.Extensions.Logging;

namespace CrvService.Common
{
    public class ExecutingContext
    {
        public ExecutingContext() : this(new CancellationTokenSource())
        {
        }

        public ExecutingContext(string eventId) : this(new CancellationTokenSource())
        {
            EventId = eventId.GetEventId();
        }

        public ExecutingContext(CancellationTokenSource cancellationTokenSource)
        {
            CancellationTokenSource = cancellationTokenSource;
            CancellationToken = CancellationTokenSource.Token;
        }

        public ExecutingContext(CancellationToken cancellationToken)
        {
            CancellationToken = cancellationToken;
        }

        protected ExecutingContext(ExecutingContext executingContext)
        {
            CancellationTokenSource = executingContext.CancellationTokenSource;
            CancellationToken = executingContext.CancellationToken;
            EventId = executingContext.EventId;
            Sw = executingContext.Sw;
        }

        public CancellationTokenSource CancellationTokenSource { get; }
        public CancellationToken CancellationToken { get; }
        public EventId EventId { get; set; } = Guid.NewGuid().ToString().GetEventId();
        public Stopwatch Sw { get; set; } = Stopwatch.StartNew();
        public long Iteration { get; set; }
    }
}