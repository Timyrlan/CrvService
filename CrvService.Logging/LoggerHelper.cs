using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CrvService.Logging
{
    public static class LoggerHelper
    {
        static LoggerHelper()
        {
            JsonSerializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                //Formatting = Formatting.Indented
            };
            JsonSerializerSettings.Converters.Add(new StringEnumConverter());

            JsonSerializerSettingsIndented = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            JsonSerializerSettingsIndented.Converters.Add(new StringEnumConverter());
        }

        private static JsonSerializerSettings JsonSerializerSettings { get; }
        private static JsonSerializerSettings JsonSerializerSettingsIndented { get; }


        public static string ToLog(this object obj)
        {
            return ToLog(obj, JsonSerializerSettings);
        }

        private static string ToLog(object obj, JsonSerializerSettings jsonSerializerSettings)
        {
            if (obj == null) return "null";

            return obj.GetType().Name + "|" + JsonConvert.SerializeObject(obj, jsonSerializerSettings).Replace("\\\"", "\"");
        }

        public static string ToLogIndented(this object obj)
        {
            return ToLog(obj, JsonSerializerSettingsIndented);
        }
    }
}