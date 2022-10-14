using RedRainLearningPortal.Api.Extensions;
using System.Text.Json;

namespace RedRainLearningPortal.Api.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = e.GetStatusCode();

            await context.Response.WriteAsync(JsonSerializer.Serialize(e.GetExceptionResponse()));
        }
    }
}
