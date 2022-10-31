namespace RedRainLearningPortal.DataAccess.Models.Requests.UserRequests
{
    public class DeleteUser : GuidBasedRequest
    {
        public DeleteUser() { }

        public DeleteUser(Guid guid) : base(guid) { }

        public override string GenerateSql() => Delete.Command("[User]", "Guid = @Guid");
    }
}
