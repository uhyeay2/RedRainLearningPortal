using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;

namespace RedRainLearningPortal.DataAccess.Tests.UserTests
{
    public class InsertUserTests : BaseTest
    {
        private readonly InsertUser _testRequest = new("InsertUser@Test.Com", "InsertTestAccount", "InsertTestPlayerName");

        [Test]
        public async Task InsertUser_Given_UserIsInserted_Should_ReturnOne() => (await _dataHandler.ExecuteAsync(_testRequest)).ShouldBe(1);

        [Test]
        public async Task InsertUser_Given_EmailAlreadyExists_Should_ReturnNegativeOne()
        {
            await InsertUser(email: _testRequest.Email);

            (await _dataHandler.ExecuteAsync(_testRequest)).ShouldBe(-1);
        }

        [Test]
        public async Task InsertUser_Given_AccountAlreadyExists_Should_ReturnNegativeOne()
        {
            await InsertUser(accountName: _testRequest.AccountName);

            (await _dataHandler.ExecuteAsync(_testRequest)).ShouldBe(-1);
        }
    }
}
