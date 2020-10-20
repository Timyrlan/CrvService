using System;
using Microsoft.Extensions.Configuration;

namespace CrvService.Configuration
{
    public static class AppConfigurations
    {
        public const string NlogFileName = "NLog.config";

        public const string EnvironmentVariableName = "ASPNETCORE_ENVIRONMENT";

        private static IConfigurationRoot _configurationRoot;

        public static string GetEnvironment()
        {
            return Environment.GetEnvironmentVariable(EnvironmentVariableName);
        }


        public static IConfigurationRoot Get(string path, string[] args = null)
        {
            _configurationRoot = _configurationRoot ?? BuildConfiguration(path, args);
            return _configurationRoot;
        }

        public static IConfigurationRoot GetWithEnvironment(string path, string[] args = null)
        {
            _configurationRoot = _configurationRoot ?? BuildConfigurationWithEnvironment(path, args);
            return _configurationRoot;
        }

        private static IConfigurationRoot BuildConfiguration(string path, string[] args = null)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{GetEnvironment()}.json", true)
                .AddCommandLine(args ?? new string[0]);

            builder = builder.AddEnvironmentVariables();

            return builder.Build();
        }

        private static IConfigurationRoot BuildConfigurationWithEnvironment(string path, string[] args = null)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{GetEnvironment()}.json", false)
                .AddEnvironmentVariables()
                .AddCommandLine(args ?? new string[0]);

            builder = builder.AddEnvironmentVariables();

            return builder.Build();
        }
    }
}