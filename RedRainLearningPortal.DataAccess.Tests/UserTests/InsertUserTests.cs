using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;

namespace RedRainLearningPortal.DataAccess.Tests.UserTests
{
    public class InsertUserTests : BaseTest
    {
        private InsertUser _testRequest => new(_testUser.Email, _testUser.AccountName, _testUser.FirstName, _testUser.LastName);

        [Test]
        public async Task InsertUser_Given_UserIsInserted_Should_ReturnOne() => (await _dataHandler.ExecuteAsync(_testRequest)).ShouldBe(1);

        [Test]
        public async Task InsertUser_Given_EmailAlreadyExists_Should_ReturnNegativeOne()
        {
            await SeedUser(email: _testRequest.Email);

            (await _dataHandler.ExecuteAsync(_testRequest)).ShouldBe(-1);
        }

        [Test]
        public async Task InsertUser_Given_AccountAlreadyExists_Should_ReturnNegativeOne()
        {
            await SeedUser(accountName: _testRequest.AccountName);

            (await _dataHandler.ExecuteAsync(_testRequest)).ShouldBe(-1);
        }
    }
}
