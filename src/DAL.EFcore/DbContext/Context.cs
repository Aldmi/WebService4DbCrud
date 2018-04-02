using System.IO;
using DAL.EFcore.Entyties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using DAL.EFcore.DbContext.EntityConfiguration;
using Library.ForConfigFiles;
using Microsoft.Extensions.Configuration;


namespace DAL.EFcore.DbContext
{

    public sealed class Context : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly string _connStr;  // строка подключенния


        #region Reps

        public DbSet<EfStation> EfStations { get; set; }
        public DbSet<EfRoute> EfRoutes { get; set; }

        #endregion




        #region ctor


        //public Context()
        //{
        //    //Отключение Tracking для всего контекста
        //    ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        //}

        public Context(string connStr)
        {
            _connStr = connStr;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #endregion



        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Context сам получает строку подключения при миграции и работе.
            //(Рабоатет для миграции и работы!!!!!!!)


            // var config = JsonConfigLib.GetConfiguration();
            //var connectionString = config.GetConnectionString("MainDbConnection");
            //optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseSqlServer(connectionString, ob => ob.MigrationsAssembly(typeof(Context).GetTypeInfo().Assembly.GetName().Name));\

            optionsBuilder.UseSqlServer(_connStr);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EfRouteConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}