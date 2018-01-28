using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CommunicationDevices.ExchangeBehavior.Http;
using DAL.Concrete;
using DAL.EFcore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using QuartzSheduler;
using QuartzSheduler.Quartz;
using Serilog;
using WebApi.Middleware;
using ILogger = Microsoft.Extensions.Logging.ILogger;


namespace WebApi
{
    public sealed class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

 



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //TODO: connString брать из настрек
            var connString = @"Server=(localdb)\mssqllocaldb;Database=SuperDb;Trusted_Connection=True;";
            services.AddTransient<IStationRepository>(s => new EfStationsRepository());

            //services.AddTransient<HttpBaseExchangeBehavior>();


            services.AddSingleton<QuartzStartup>();
        }



        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            ConfigurationBackgroundProcess(app);


            //КОНВЕЕР ОБРАБОТКИ ЗАПРОСА
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<SerilogEnricherContextMiddleware>();
            app.UseMiddleware<HealthCheckMiddleware>();

            app.UseMvc();
        }


        public void ConfigurationBackgroundProcess(IApplicationBuilder app)
        {
            //Запуск Quartz задач.
            //TODO: в ctor QuartzStartup передовать все сервисы нужные для Jobs (в Job попадают через Map при настройки Job).
            // ApplicationStarted(app);
            ApplicationStopping(app);
        }


        private void ApplicationStarted(IApplicationBuilder app)
        {
            var lifetime= app.ApplicationServices.GetService<IApplicationLifetime>();

            var quartz= app.ApplicationServices.GetService<QuartzStartup>();
            lifetime.ApplicationStarted.Register(quartz.Start);
        }


        private void ApplicationStopping(IApplicationBuilder app)
        {
            var lifetime= app.ApplicationServices.GetService<IApplicationLifetime>();
            var quartz= app.ApplicationServices.GetService<QuartzStartup>();

            lifetime.ApplicationStopping.Register(quartz.Stop);
            lifetime.ApplicationStopping.Register(Library.Log.Logger.CloseAndFlush);
        }
    }
}
