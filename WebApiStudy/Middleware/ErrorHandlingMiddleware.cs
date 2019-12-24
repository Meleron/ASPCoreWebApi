using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WebApiStudy.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate _next)
        {
            next = _next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var info = new { stackTrace = ex.StackTrace, message = ex.Message};
            context.Response.ContentType = "application/json";
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            string output = JsonConvert.SerializeObject(info, jsonSettings);
            await context.Response.WriteAsync(output);            
        }
    }

    public static class ErrorHandlingExtension
    {
        public static IApplicationBuilder UseErrorHandlnig(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware(typeof(ErrorHandlingMiddleware));
        }
    }
}
