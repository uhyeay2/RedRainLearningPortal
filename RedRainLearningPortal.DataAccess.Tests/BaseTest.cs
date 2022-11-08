using Moq;
using RedRainLearningPortal.DataAccess.Interfaces;
using RedRainLearningPortal.Domain.Interfaces;

namespace RedRainLearningPortal.DataAccess.Tests
{
    [TestFixture]
    public class BaseTest
    {
        public BaseTest()
        {
            var mockedConfig = new Mock<IConfig>();

            mockedConfig.Setup(_ => _.GetConnectionString(It.IsAny<string>())).Returns(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RedRainLearningPortalTestEnv;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            _dataHandler = new DataHandler(mockedConfig.Object);

            _databaseController = new(_dataHandler);
        }

        // DataHandler used to execute requests
        protected readonly IDataHandler _dataHandler;

        // Used to Seed/Clear Database
        private readonly TestDatabaseController _databaseController;

        #region Test Objects

        protected Guid _randomGuid;

        private IEnumerable<char> _randomPrefix => _randomGuid.ToString().Take(4);

        protected UserDTO _testUser => new()
        {
            Identifier = _randomGuid,
            Email = _randomPrefix + "-Test@Email.com",
            AccountName = _randomPrefix + "-AccountName",
            FirstName = _randomPrefix + "-FirstName",
            LastName = _randomPrefix + "-LastName"
        };

        protected OrganizationDTO _testOrganization => new()
        {
            Identifier = Guid.NewGuid(),
            Name = _randomPrefix + "-OrganizationName",
            Description = _randomPrefix + " - Organization Description"
        };

        #endregion

        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            _randomGuid = Guid.NewGuid();
        }

        [TearDown]
        public async Task TearDownAsync()
        {
            await _databaseController.ClearTables();
        }

        #endregion

        /// <summary> Used to fetch an object from database using InlineSql without using any other request objects </summary>
        protected async Task<DTO?> Fetch<DTO>(string sql) => await _databaseController.Fetch<DTO?>(sql);

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
