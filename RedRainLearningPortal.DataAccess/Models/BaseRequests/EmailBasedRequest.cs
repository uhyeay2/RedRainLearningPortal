namespace RedRainLearningPortal.DataAccess.Models.BaseRequests
{
    public abstract class EmailBasedRequest : IRequestObject
    {
        public string? Email { get; set; }

        public object? GenerateParameters() => new { Email };

        public abstract string GenerateSql();
    }
}
