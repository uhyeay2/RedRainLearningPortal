namespace RedRainLearningPortal.DataAccess.Models.Requests.UserRequests
{
    public class DeleteUser : GuidBasedRequest
    {
        public DeleteUser(Guid guid) : base(guid) { }

        private string _sql => SqlGenerator.Delete("User", "Guid = @Guid");

        public override string GenerateSql() => _sql;
    }
}
