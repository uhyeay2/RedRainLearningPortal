namespace RedRainLearningPortal.DataAccess.Models.Requests.OrganizationRequests
{
    public class GetOrganizationByGuid : GuidBasedRequest
    {
        public GetOrganizationByGuid() { }

        public GetOrganizationByGuid(Guid guid) : base(guid) { }

        public override string GenerateSql() => _sql;

        private static readonly string _sql = Fetch.ReflectionQuery<OrganizationDTO>();
    }
}
