namespace RedRainLearningPortal.DataAccess.Models.BaseRequests
{
    public abstract class EmailBasedRequest : IRequestObject
    {
        protected EmailBasedRequest() { }

        protected EmailBasedRequest(string? email) => Email = email;

        public string? Email { get; set; }

        public object? GenerateParameters() => new { Email };

        public abstract string GenerateSql();
    }
}
