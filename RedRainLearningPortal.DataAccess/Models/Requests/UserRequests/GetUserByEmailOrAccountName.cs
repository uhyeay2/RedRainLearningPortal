namespace RedRainLearningPortal.DataAccess.Models.Requests.UserRequests
{
    public class GetUserByEmailOrAccountName : IRequestObject
    {
        public string? Email { get; set; }
        public string? AccountName { get; set; }

        public object? GenerateParameters() => new { Email, AccountName };

        public string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.Fetch(typeof(UserDTO),
            whereOverride: "(Email = @Email AND @AccountName IS NULL) OR (AccountName = @AccountName AND @Email IS NULL)");
    }
}
