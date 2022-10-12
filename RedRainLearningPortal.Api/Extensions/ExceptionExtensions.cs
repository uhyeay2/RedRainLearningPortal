using RedRainLearningPortal.Domain.Models;
using RedRainLearningPortal.Mediator.Abstractions.Responses;

namespace RedRainLearningPortal.Api.Extensions
{
    public static class ExceptionExtensions
    {
        public static int GetStatusCode(this Exception e) => e switch
        {
            BadRequestException => 400,
            _ => 500
        };

        public static BaseResponse GetExceptionResponse(this Exception e) => e switch
        {
            BadRequestException => Response.BadRequest(e.Message),
            //NotFoundException => StatusCodes.Status404NotFound,
            //AlreadyExistsException => StatusCodes.Status409Conflict,
            _ => Response.Unexpected(e.Message)
        };
    }
}
