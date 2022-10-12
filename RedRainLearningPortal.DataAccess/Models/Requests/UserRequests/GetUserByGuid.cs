﻿namespace RedRainLearningPortal.DataAccess.Models.Requests.UserRequests
{
    internal class GetUserByGuid : EmailBasedRequest
    {
        private static readonly string _sql = SqlGenerator.Fetch(typeof(UserDTO));

        public override string GenerateSql() => _sql;
    }
}
