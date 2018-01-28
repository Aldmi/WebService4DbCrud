using System;
using System.Linq;
using Library.ForConfigFiles;
using Serilog;
using Serilog.Context;
using Serilog.Core;

namespace Library.Log
{
    public static class Logger
    {
        static Logger()
        {
            var config = JsonConfigLib.GetConfiguration();
            Serilog.Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();
        }



        public static IDisposable PushEnrichers(params ILogEventEnricher[] enrichers)
        {
            return LogContext.Push(enrichers.ToArray());
        }

        public static void Debug(string messageTemplate)
        {
            Serilog.Log.Debug(messageTemplate);
        }

        public static void Information(string messageTemplate)
        {
            Serilog.Log.Information(messageTemplate);
        }

        public static void Error(string messageTemplate)
        {
            Serilog.Log.Error(messageTemplate);
        }

        public static void Fatal(string messageTemplate)
        {
            Serilog.Log.Fatal(messageTemplate);
        }

        public static void CloseAndFlush()
        {
            if(Serilog.Log.Logger == null)
                return;

            Serilog.Log.CloseAndFlush();
        }
    }
}