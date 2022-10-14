namespace RedRainLearningPortal.DataAccess.Models.Requests.UserRequests
{
    public class IsAccountNameTaken : IRequestObject
    {
        public string AccountName { get; set; }

        public IsAccountNameTaken(string accountName) => AccountName = accountName;

        public object? GenerateParameters() => new { AccountName };

        public string GenerateSql() => _sql;
        
        private static readonly string _sql = SqlGenerator.SelectExists("[User]", "AccountName = @AccountName");
    }
}
