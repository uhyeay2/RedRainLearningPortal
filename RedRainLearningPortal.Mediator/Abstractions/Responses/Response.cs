namespace RedRainLearningPortal.Mediator.Abstractions.Responses
{
    public static class Response
    {
        public static BaseResponse Success() =>
            new(statusCode: 200, success: true, message: "Success");

        public static BaseResponse<object?> Success(object content) => 
            new(statusCode: 200, success: true, message: "Success", content);

        public static BaseResponse<List<string>> ValidationFailed(List<string> validationErrors) =>  
            new(statusCode: 400, success: false, message: "Request Validation Failed!", content: validationErrors);

        public static BaseResponse NotFound(string objectNotFound, string paramsProvided, bool success = false) => 
            new(statusCode: 404, success, message: $"{objectNotFound} was not found with {paramsProvided}");

        public static BaseResponse AlreadyExists(string objectAlreadyExisting, string conflictingItems, bool success = false) => 
            new(statusCode: 409, success, message: $"object ({objectAlreadyExisting}) already exists with {conflictingItems}");

        public static BaseResponse<Exception> Exception(Exception e, string? message = null) => 
            new(statusCode: 500, success: false, message: string.IsNullOrWhiteSpace(message) ? e.Message : message, e);

        public static BaseResponse Unexpected(string message, bool success = false) => 
            new(statusCode: 500, success, message);
    }
}
