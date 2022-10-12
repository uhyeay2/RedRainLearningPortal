namespace RedRainLearningPortal.DataAccess.Models.Requests.UserRequests
{
    public class IsEmailRegistered : EmailBasedRequest
    {
        private static readonly string _sql = SqlGenerator.SelectExists("User", "Email = @Email");

        public override string GenerateSql() => _sql;
    }
}
