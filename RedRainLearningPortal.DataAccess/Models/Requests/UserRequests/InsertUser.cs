namespace RedRainLearningPortal.DataAccess.Models.Requests.UserRequests
{
    [InsertQuery("[User]", ifNotExists: "SELECT * FROM [User] WITH(NOLOCK) WHERE Email = @Email OR AccountName = @AccountName")]
    public class InsertUser : IRequestObject
    {
        public InsertUser(string email, string accountName, string? name)
        {
            Email = email;
            AccountName = accountName;
            Name = name;
        }

        [Insertable("[User]")]
        public string Email { get; set; }

        [Insertable("[User]")]
        public string AccountName { get; set; }

        [Insertable("[User]")]
        public string? Name { get; set; }

        public object? GenerateParameters() => new { Email, AccountName, Name };

        public string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.Insert(typeof(InsertUser));
    }
}
