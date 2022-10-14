using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;

namespace RedRainLearningPortal.DataAccess.Tests.UserTests
{
    public class GetUserByEmailOrAccountNameTests : BaseTest
    {
        #region Get By Email

        [Test]
        public async Task GetUserByEmail_Given_NoUserWithEmail_Should_ReturnNull() => (await _dataHandler
            .FetchAsync<GetUserByEmailOrAccountName, UserDTO>(new() { Email = _testUser.Email })).ShouldBeNull();

        [Test]
        public void GetUserByEmail_Given_UserExistsWithEmail_Should_ReturnUser() =>
            Assert.Multiple(async () =>
            {
                await InsertUser(_testUser.Identifier, _testUser.Email, _testUser.AccountName, _testUser.Name);

                var user = await _dataHandler.FetchAsync<GetUserByEmailOrAccountName, UserDTO>(
                    new() { Email = _testUser.Email });

                user.ShouldNotBeNull();
                user.Identifier.ShouldBe(_testUser.Identifier);
                user.AccountName.ShouldBe(_testUser.AccountName);
                user.Name.ShouldBe(_testUser.Name);
                user.Email.ShouldBe(_testUser.Email);
            });

        #endregion

        #region Get By Account Name 

        [Test]
        public async Task GetUserByAccountName_Given_NoUserWithAccountName_Should_ReturnNull() => (await _dataHandler
            .FetchAsync<GetUserByEmailOrAccountName, UserDTO>(new() { AccountName = _testUser.AccountName})).ShouldBeNull();

        [Test]
        public void GetUserByAccountName_Given_UserExistsWithAccountName_Should_ReturnUser() =>
            Assert.Multiple(async () =>
            {
                await InsertUser(_testUser.Identifier, _testUser.Email, _testUser.AccountName, _testUser.Name);

                var user = await _dataHandler.FetchAsync<GetUserByEmailOrAccountName, UserDTO>(
                    new() { AccountName = _testUser.AccountName });

                user.ShouldNotBeNull();
                user.Identifier.ShouldBe(_testUser.Identifier);
                user.AccountName.ShouldBe(_testUser.AccountName);
                user.Name.ShouldBe(_testUser.Name);
                user.Email.ShouldBe(_testUser.Email);
            });

        #endregion
    }
}
