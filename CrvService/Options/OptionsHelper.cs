using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrvService.Options
{
    public static class OptionsHelper
    {
        public static readonly Dictionary<Type, string> OptionsToInitialize = new Dictionary<Type, string>();

        public static string GetOptionsName<TOptions>()
        {
            return typeof(TOptions).Name;
        }

        public static void AddOptions<TOptions>(this IServiceCollection services, IConfigurationRoot configuration) where TOptions : class, new()
        {
            var name = typeof(TOptions).Name;
            services.Configure<TOptions>(configuration.GetSection(name));
        }

        public static void AddOptions<TOptions>(this IServiceCollection services, IConfiguration configuration) where TOptions : class, new()
        {
            var name = typeof(TOptions).Name;
            services.Configure<TOptions>(configuration.GetSection(name));
        }

        //public static void AddPeriodicService<TPeriodicService, TOptions>(this IServiceCollection serviceCollection, IConfiguration configuration)
        //    where TOptions : PeriodicServiceOptions, new()
        //    where TPeriodicService : PeriodicServiceBase<TOptions>
        //{
        //    serviceCollection.AddSingleton<IHostedService, TPeriodicService>();
        //    serviceCollection.AddOptions<TOptions>(configuration);
        //}

        //public static void AddHubsService<TUpdateEntityHubPeriodicService, TOptions>(this IServiceCollection services, IConfiguration configuration)
        //    where TUpdateEntityHubPeriodicService : class, IHostedService
        //    where TOptions : PeriodicServiceOptions, new()
        //{
        //    services.AddSingleton<IHostedService, TUpdateEntityHubPeriodicService>();
        //    services.AddOptions<TOptions>(configuration);
        //}
    }
}