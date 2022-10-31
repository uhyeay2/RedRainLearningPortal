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

        protected OrganizationDTO _testOrganization = null!;

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
                Email = randomPrefix + "-Test@Email.com",
                AccountName = randomPrefix + "-AccountName",
                FirstName = randomPrefix + "-FirstName",
                LastName = randomPrefix + "-LastName"
            };

            _testOrganization = new()
            {
                Identifier = Guid.NewGuid(),
                Name = randomPrefix + "-OrganizationName",
                Description = randomPrefix + " - Organization Description"
            };
        }

        [TearDown]
        public async Task TearDownAsync()
        {
            await _databaseController.ClearTables();
        }

        public async Task<DTO?> Fetch<DTO>(string sql) => await _databaseController.Fetch<DTO?>(sql);

        #region Seed Data

        protected async Task SeedUser(Guid? guid = null, string? email = null, string? accountName = null, string? firstName = null, string? lastName = null) =>
            await _databaseController.Execute($"INSERT INTO [User] ( Guid, Email, AccountName, FirstName, LastName ) VALUES ( '{guid ?? _testUser.Identifier}',  " +
                $"'{email ?? _testUser.Email}', '{accountName ?? _testUser.AccountName}', '{firstName ?? _testUser.FirstName}', '{lastName ?? _testUser.LastName}' )");

        protected async Task SeedOrganization(Guid? guid = null, string? name = null, string? description = null) =>
            await _databaseController.Execute($"INSERT INTO Organization (Guid, Name, Description) VALUES ( '{guid ?? _testOrganization.Identifier}' , " +
                $"'{name ?? _testOrganization.Name}', '{_testOrganization.Description}' )");

        #endregion
    }
}
