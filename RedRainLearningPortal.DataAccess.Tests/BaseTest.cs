using Moq;
using RedRainLearningPortal.DataAccess.Interfaces;
using RedRainLearningPortal.Domain.Interfaces;

namespace RedRainLearningPortal.DataAccess.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected readonly IDataHandler _dataHandler;

        private readonly TestDatabaseController _databaseController;

        protected Guid _randomGuid;

        protected UserDTO _testUser = null!;

        public BaseTest()
        {
            var mockedConfig = new Mock<IConfig>();

            mockedConfig.Setup(_ => _.GetConnectionString(It.IsAny<string>())).Returns(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RedRainLearningPortalTestEnv;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            _dataHandler = new DataHandler(mockedConfig.Object);

            _databaseController = new(_dataHandler);
        }

        [SetUp]
        public void Setup()
        {
            _randomGuid = Guid.NewGuid();

            var randomPrefix = _randomGuid.ToString().Take(4);

            _testUser = new()
            {
                Identifier = _randomGuid,
                Email = randomPrefix + "Test@Email.com",
                AccountName = randomPrefix + "TestAcc",
                Name = randomPrefix + "TestName"
            };
        }

        [TearDown]
        public async Task TearDownAsync()
        {
            await _databaseController.ClearTables();
        }

        public async Task<DTO?> Fetch<DTO>(string sql) => await _databaseController.Fetch<DTO?>(sql);

        #region Seed Data

        protected async Task InsertUser(Guid? guid = null, string? email = null, string? accountName = null, string? name = null) =>
            await _databaseController.Execute($"INSERT INTO [User] ( Guid, Email, AccountName, Name ) VALUES ( '{guid ?? _testUser.Identifier}',  " +
                $"'{email ?? _testUser.Email}', '{accountName ?? _testUser.AccountName}', '{name ?? _testUser.Name}' )");

        #endregion
    }
}
