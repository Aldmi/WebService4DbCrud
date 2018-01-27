using System.IO;
using DAL.EFcore.Entyties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using DAL.EFcore.DbContext.EntityConfiguration;
using Microsoft.Extensions.Configuration;


namespace DAL.EFcore.DbContext
{

    public sealed class Context : Microsoft.EntityFrameworkCore.DbContext
    {
        #region Reps

        public DbSet<EfStation> EfStations { get; set; }
        public DbSet<EfRoute> EfRoutes { get; set; }

        #endregion



        #region ctor
        public Context()
        {
            //Отключение Tracking для всего контекста
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        #endregion




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            var connectionString = config.GetConnectionString("MainDbConnection");
            
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseSqlServer(connectionString, ob => ob.MigrationsAssembly(typeof(Context).GetTypeInfo().Assembly.GetName().Name));
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EfRouteConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}