using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Serilog.Context;
using Serilog.Core;
using Serilog.Core.Enrichers;

namespace WebApi.Middleware
{

    //Добавить дополнительную информацию к выводу в лог.
    //Для каждого запроса сохраняются как доп. парметры лога ClientIP и UserAgent.  При вызове Log.Debug("Error...") к логу добавится инфа про пользователя;
    public class SerilogEnricherContextMiddleware
    {
        private readonly RequestDelegate _next;

        public SerilogEnricherContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var enrichers = new Stack<ILogEventEnricher>();
            var clientIpEnricher = new PropertyEnricher("ClientIP", context.Connection.RemoteIpAddress);
            enrichers.Push(clientIpEnricher);

            var userAgent = context.Request.Headers[HeaderNames.UserAgent].ToString();
            if (!string.IsNullOrEmpty(userAgent))
            {
                var userAgentEnricher = new PropertyEnricher("UserAgent", userAgent);
                enrichers.Push(userAgentEnricher);
            }

            using (LogContext.Push(enrichers.ToArray()))
            {
                await _next(context);
            }
        }
    }
}