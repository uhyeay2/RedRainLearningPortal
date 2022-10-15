namespace RedRainLearningPortal.Domain.Models
{
    public class RequestValidationException : Exception
    {
        public RequestValidationException(List<string> validationErrors) => ValidationErrors = validationErrors;

        public readonly List<string> ValidationErrors;
    }
}
