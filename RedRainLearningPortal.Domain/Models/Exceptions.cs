namespace RedRainLearningPortal.Domain.Models
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string? message) : base(message) { }
    }
}
