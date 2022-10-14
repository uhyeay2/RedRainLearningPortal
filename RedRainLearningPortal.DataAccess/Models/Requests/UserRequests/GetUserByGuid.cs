namespace RedRainLearningPortal.DataAccess.Models.Requests.UserRequests
{
    public class GetUserByGuid : GuidBasedRequest
    {
        public GetUserByGuid(Guid guid) : base(guid) { }

        public GetUserByGuid() { }

        public override string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.Fetch(typeof(UserDTO));
    }
}
