using CrvService.Data;
using CrvService.Options;
using CrvService.ServerSide;
using CrvService.Shared.Logic;
using CrvService.Shared.Logic.ClientSide;
using CrvService.Shared.Logic.ClientSide.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace CrvService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions<Logging.Logging>(Configuration);


            services.AddSingleton<IProcessorsProvider, ProcessorsProvider>();


            AddServerServerSide(services);
            //AddServerClientSide(services);

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Use the default property (Pascal) casing
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();

                // Configure a custom converter
                //options.SerializerOptions.Converters.Add(new MyCustomJsonConverter());
            });
        }

        private static void AddServerClientSide(IServiceCollection services)
        {
            services.AddSingleton<IPlayerRepository, PlayerRepositoryClientSide>();
            services.AddSingleton<IWorldRepository, WorldRepositoryClientSide>();
            services.AddSingleton<INewInstanceFactory, NewInstanceFactoryClientSide>();
            services.AddSingleton<ICaravanServer, CaravanServerClientSide>();
            services.AddSingleton<INewWorldGenerator, NewWorldGenerator>();
        }

        private void AddServerServerSide(IServiceCollection services)
        {
            services.AddSingleton<INewInstanceFactory, NewInstanceFactoryEntity>();
            services.AddOptions<CrvServiceContextOptions>(Configuration);
            services.AddSingleton<ICaravanServer, CaravanServerEntity>();
            services.AddSingleton<ICrvServiceContextFactory, CrvServiceContextFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}