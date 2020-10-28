using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using CrvService.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using NLog.Web;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace CrvService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"Starting CrvService with environment {AppConfigurations.GetEnvironment()}");
            var logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();

            MappedDiagnosticsLogicalContext.Set("host_name", $"{Dns.GetHostName()}");
            MappedDiagnosticsLogicalContext.Set("host_ip", $"{JsonConvert.SerializeObject(Dns.GetHostAddresses(Dns.GetHostName()).Select(c => c.ToString()))}");

            try
            {
                var environment = AppConfigurations.GetEnvironment();
                var ipAddresses = string.Join("|", Dns.GetHostAddressesAsync(Dns.GetHostName()).Result.Select(c => c.ToString()));
                var version = Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

                try
                {
                    logger.Info($"Starting CrvService. environment:{environment}, ipAddresses:{ipAddresses}, version:{version}");
                    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
                    var host = CreateHostBuilder(args).Build();
                    host.Run();
                }
                catch (Exception e)
                {
                    logger.Fatal(e, $"Fatal exception during working CrvService. environment:{environment}, ipAddresses:{ipAddresses}, version:{version}");
                }
                finally
                {
                    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                    LogManager.Shutdown();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fatal error while CrvService {e}");
            }

            Console.WriteLine($"Finish CrvService with environment {AppConfigurations.GetEnvironment()}");
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                        webBuilder.UseConfiguration(AppConfigurations.GetWithEnvironment(Directory.GetCurrentDirectory(), args));
                        webBuilder.UseEnvironment(AppConfigurations.GetEnvironment());
                    })
                    .ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.SetMinimumLevel(LogLevel.Trace);
                    })
                    .UseNLog()
                    .UseEnvironment(AppConfigurations.GetEnvironment())
                ;
        }
    }
}