using RedRainLearningPortal.DataAccess.Interfaces;
using RedRainLearningPortal.DataAccess.Models.BaseRequests;

namespace RedRainLearningPortal.DataAccess.Tests
{
    internal class TestDatabaseController
    {
        protected readonly IDataHandler _dataHandler;

        public TestDatabaseController(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        public async Task ClearTables()
        {
            await Execute("DELETE FROM [User]" );
            await Execute("DELETE FROM Organization");
        }

        public async Task<TOutput?> Fetch<TOutput>(string sql) => await _dataHandler.FetchAsync<InlineSqlRequest, TOutput>(new(sql));

        public async Task<int> Execute(string sql) => await _dataHandler.ExecuteAsync(new InlineSqlRequest(sql));

        private class InlineSqlRequest : ParameterlessRequest
        {
            public InlineSqlRequest(string sql) => _sql = sql;

            private readonly string _sql;

            public override string GenerateSql() => _sql;
        }
    }
}
