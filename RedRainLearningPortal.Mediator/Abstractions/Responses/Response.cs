namespace RedRainLearningPortal.Mediator.Abstractions.Responses
{
    public static class Response
    {
        public static BaseResponse<object?> Success(object? content = null) => new(200, true, "Success", content);

        public static BaseResponse BadRequest(string message, bool success = false) => new(400, success, message);

        public static BaseResponse NotFound(string message, bool success = false) => new(404, success, message);

        public static BaseResponse AlreadyExists(string message, bool success = false) => new(409, success, message);

        public static BaseResponse Unexpected(string message, bool success = false) => new(500, success, message);

        public static BaseResponse<Exception> Exception(Exception e, string? message = null) => new(500, false, string.IsNullOrWhiteSpace(message) ? e.Message : message, e);
    }
}
