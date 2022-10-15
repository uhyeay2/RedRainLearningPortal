using RedRainLearningPortal.Domain.Models;
using RedRainLearningPortal.Mediator.Abstractions.Responses;

namespace RedRainLearningPortal.Api.Extensions
{
    public static class ExceptionExtensions
    {
        public static int GetStatusCode(this Exception e) => e switch
        {
            RequestValidationException => 400,
            _ => 500
        };

        public static BaseResponse GetExceptionResponse(this Exception e) => e switch
        {
            RequestValidationException => Response.ValidationFailed((e as RequestValidationException)!.ValidationErrors),            
            _ => Response.Exception(e)
        };
    }
}
