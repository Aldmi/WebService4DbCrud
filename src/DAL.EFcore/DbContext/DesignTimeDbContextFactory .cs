﻿using System.IO;
using Library.ForConfigFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAL.EFcore.DbContext
{
    /// <summary>
    /// Получение контекста для системы миграции (если конструктор контекста принимает парметры)
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var config = JsonConfigLib.GetConfiguration();
            var connectionString = config.GetConnectionString("MainDbConnection");
            return new Context(connectionString);
        }
    }
}