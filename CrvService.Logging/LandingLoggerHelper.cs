using System;
using Microsoft.Extensions.Logging;

namespace CrvService.Logging
{
    public static class LandingLoggerHelper
    {
        public static EventId GetEventId(this string guid)
        {
            if (!string.IsNullOrWhiteSpace(guid))
                if (Guid.TryParse(guid, out var parced))
                    return new EventId(parced.GetHashCode(), guid);

            return new EventId(int.MaxValue, guid);
        }

        public static EventId GetEventIdFromString(this string id)
        {
            return new EventId(int.MaxValue, id);
        }
    }
}