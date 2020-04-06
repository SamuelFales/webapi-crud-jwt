using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Infra.Configuration.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static void AddCorsHeaders(this IApplicationBuilder appBuilder)
        {
            appBuilder.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Access-Control-Allow-Headers", "content-type,authorization,token");
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                context.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,OPTIONS");
                await next.Invoke();
            });
        }
    }
}
