using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;

namespace RedRainLearningPortal.DataAccess.Tests.UserTests
{
    public class IsAccountNameTakenTests : BaseTest
    {
        [Test]
        public async Task IsAccountNameTaken_Given_AccountNameNotTaken_Should_ReturnFalse() =>
            (await _dataHandler.FetchAsync<IsAccountNameTaken, bool>(new(_testUser.AccountName))).ShouldBeFalse();

        [Test]
        public async Task IsAccountNameTaken_Given_AccountNameTaken_Should_ReturnTrue()
        {
            await InsertUser(accountName: _testUser.AccountName);

            (await _dataHandler.FetchAsync<IsAccountNameTaken, bool>(new(_testUser.AccountName))).ShouldBeTrue();
        }
    }
}
