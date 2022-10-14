namespace RedRainLearningPortal.DataAccess.Models.Requests.UserRequests
{
    public class DeleteUser : GuidBasedRequest
    {
        public DeleteUser(Guid guid) : base(guid) { }

        public override string GenerateSql() => _sql;
            
        private static readonly string _sql = SqlGenerator.Delete("[User]", "Guid = @Guid");
    }
}
