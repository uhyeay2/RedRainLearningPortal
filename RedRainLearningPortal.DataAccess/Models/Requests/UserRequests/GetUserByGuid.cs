﻿namespace RedRainLearningPortal.DataAccess.Models.Requests.UserRequests
{
    public class GetUserByGuid : GuidBasedRequest
    {
        public GetUserByGuid() { }

        public GetUserByGuid(Guid guid) : base(guid) { }

        public override string GenerateSql() => _sql;

        private static readonly string _sql = Fetch.ReflectionQuery<UserDTO>();
    }
}
