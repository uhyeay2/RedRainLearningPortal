using RedRainLearningPortal.Api.Extensions;
using RedRainLearningPortal.Domain.Models;
using RedRainLearningPortal.Mediator.Abstractions.Responses;
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

            if(e is RequestValidationException exception)
            {
                await context.Response.WriteAsync(JsonSerializer.Serialize(Response.ValidationFailed(exception.ValidationErrors)));
            }
            else
            {
                await context.Response.WriteAsync(JsonSerializer.Serialize(Response.Exception(e)));
            }
        }
    }
}
