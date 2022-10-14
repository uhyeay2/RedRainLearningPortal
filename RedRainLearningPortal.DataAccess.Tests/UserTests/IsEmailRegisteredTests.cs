using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;

namespace RedRainLearningPortal.DataAccess.Tests.UserTests
{
    public class IsEmailRegisteredTests : BaseTest
    {
        [Test]
        public async Task IsEmailRegistered_Given_EmailNotRegistered_Should_ReturnFalse() =>
            (await _dataHandler.FetchAsync<IsEmailRegistered, bool>(new(_testUser.Email))).ShouldBeFalse();

        [Test]
        public async Task IsEmailRegistered_Given_EmailIsRegistered_Should_ReturnTrue()
        {
            await InsertUser(email: _testUser.Email);

            (await _dataHandler.FetchAsync<IsEmailRegistered, bool>(new(_testUser.Email))).ShouldBeTrue();
        }
    }
}
