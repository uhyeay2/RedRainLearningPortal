namespace RedRainLearningPortal.DataAccess.Models.Requests.UserRequests
{
    [InsertQuery("[User]", ifNotExists: "SELECT * FROM [User] WITH(NOLOCK) WHERE Email = @Email OR AccountName = @AccountName")]
    public class InsertUser : IRequestObject
    {
        #region Constructors

        public InsertUser() { }

        public InsertUser(string email, string accountName, string firstName, string lastName)
        {
            Email = email;
            AccountName = accountName;
            FirstName = firstName;
            LastName = lastName;
        }

        #endregion

        #region Properties To Insert

        [Insertable("[User]")]
        public string Email { get; set; } = null!;

        [Insertable("[User]")]
        public string AccountName { get; set; } = null!;

        [Insertable("[User]")]
        public string FirstName { get; set; } = null!;

        [Insertable("[User]")]
        public string LastName { get; set; } = null!;

        #endregion

        #region IRequestObject Obligation

        public object? GenerateParameters() => new { Email, AccountName, FirstName, LastName };

        public string GenerateSql() => _sql;

        private static readonly string _sql = Insert.ReflectionCommand<InsertUser>();

        #endregion
    }
}
