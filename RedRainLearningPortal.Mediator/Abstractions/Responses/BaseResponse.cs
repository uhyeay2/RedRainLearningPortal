namespace RedRainLearningPortal.Mediator.Abstractions.Responses
{
    public class BaseResponse : IResponse
    {
        public BaseResponse() { }

        public BaseResponse(int statusCode, bool success, string message)
        {
            StatusCode = statusCode;
            Success = success;
            Message = message;
        }

        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public static BaseResponse Conflict(string message) => new (403, false, message);
    }

    public class BaseResponse<TContent> : BaseResponse, IResponse<TContent>
    {
        public BaseResponse() { }

        public BaseResponse(int statusCode, bool success, string message) : base(statusCode, success, message) { }

        public BaseResponse(int statusCode, bool success, string message, TContent content) : base(statusCode, success, message)
        {
            Content = content;
        }

        public TContent? Content { get; set; }
    }

    public class SuccessResponse : BaseResponse<object>
    {
        public SuccessResponse(object content) : base(200, true, "Success", content) { }

        public SuccessResponse() : base(200, true, "Success") { }
    }
}
