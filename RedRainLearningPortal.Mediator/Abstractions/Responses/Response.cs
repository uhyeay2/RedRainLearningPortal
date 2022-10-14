namespace RedRainLearningPortal.Mediator.Abstractions.Responses
{
    public static class Response
    {
        public static BaseResponse<object?> Success(object? content = null) => new(200, true, "Success", content);

        public static BaseResponse BadRequest(string message, bool success = false) => new(400, success, message);

        public static BaseResponse NotFound(string objectNotFound, string paramsProvided, bool success = false) => new(404, success, $"{objectNotFound} was not found with {paramsProvided}");

        public static BaseResponse AlreadyExists(string objectAlreadyExisting, string conflictingItems, bool success = false) => new(409, success, $"object ({objectAlreadyExisting}) already exists with {conflictingItems}");

        public static BaseResponse Unexpected(string message, bool success = false) => new(500, success, message);

        public static BaseResponse<Exception> Exception(Exception e, string? message = null) => new(500, false, string.IsNullOrWhiteSpace(message) ? e.Message : message, e);
    }
}
