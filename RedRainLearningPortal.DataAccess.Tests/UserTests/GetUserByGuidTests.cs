using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;

namespace RedRainLearningPortal.DataAccess.Tests.UserTests
{
    public class GetUserByGuidTests : BaseTest
    {
        [Test]
        public async Task GetUserByGuid_Given_NoUserWithGuid_Should_ReturnNull() =>
            (await _dataHandler.FetchAsync<GetUserByGuid, UserDTO>(new (_randomGuid))).ShouldBeNull();

        [Test]
        public void GetUserByGuid_Given_UserExistsWithGuid_Should_ReturnUser() =>
            Assert.Multiple(async () =>
            {
                await SeedUser(_testUser.Identifier, _testUser.Email, _testUser.AccountName, _testUser.FirstName, _testUser.LastName);

                var user = await _dataHandler.FetchAsync<GetUserByGuid, UserDTO>(new(_testUser.Identifier));

                user.ShouldNotBeNull();
                user.Identifier.ShouldBe(_testUser.Identifier);
                user.AccountName.ShouldBe(_testUser.AccountName);
                user.FirstName.ShouldBe(_testUser.FirstName);
                user.LastName.ShouldBe(_testUser.LastName);
                user.Email.ShouldBe(_testUser.Email);
            });
    }
}
