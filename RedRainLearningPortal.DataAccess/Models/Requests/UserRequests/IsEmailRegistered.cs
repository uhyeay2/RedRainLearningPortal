namespace RedRainLearningPortal.DataAccess.Models.Requests.UserRequests
{
    public class IsEmailRegistered : EmailBasedRequest
    {
        public IsEmailRegistered(string? email) : base(email) { }

        public override string GenerateSql() => Fetch.Exists("[User]", "Email = @Email");
    }
}
