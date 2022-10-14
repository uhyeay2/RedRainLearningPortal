namespace RedRainLearningPortal.DataAccess.Models.Requests.UserRequests
{
    public class IsEmailRegistered : EmailBasedRequest
    {
        public IsEmailRegistered(string? email) : base(email) { }

        public override string GenerateSql() => _sql;
        
        private static readonly string _sql = SqlGenerator.SelectExists("[User]", "Email = @Email");
    }
}
