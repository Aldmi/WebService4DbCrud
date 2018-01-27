using System;
using System.Collections.Generic;
using System.Linq;
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


namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //TODO: connString брать из настрек
            var connString = @"Server=(localdb)\mssqllocaldb;Database=SuperDb;Trusted_Connection=True;";
            services.AddTransient<IStationRepository>(s => new EfStationsRepository());

            //services.AddTransient<HttpBaseExchangeBehavior>();

            services.AddSingleton<QuartzStartup>();
        }



        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            //Запуск Quartz задач.
            //TODO: в ctor QuartzStartup передовать все сервисы нужные для Jobs (в Job попадают через Map при настройки Job).
            //var quartz = new QuartzStartup();
            //lifetime.ApplicationStarted.Register(quartz.Start);
            //lifetime.ApplicationStopping.Register(quartz.Stop);

            ApplicationStarted(app);
            ApplicationStopping(app);


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
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
        }
    }
}
