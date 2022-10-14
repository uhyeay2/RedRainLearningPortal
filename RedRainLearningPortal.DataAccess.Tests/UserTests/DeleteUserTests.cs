using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;

namespace RedRainLearningPortal.DataAccess.Tests.UserTests
{
    [TestFixture]
    public class DeleteUserTests : BaseTest
    {
        [Test]
        public async Task DeleteUser_Given_UserDoesNotExist_Should_ReturnZero() => 
            (await _dataHandler.ExecuteAsync(new DeleteUser(_randomGuid))).ShouldBe(0);

        [Test]
        public async Task DeleteUser_Given_UserIsDeleted_Should_ReturnOne()
        {
            await InsertUser(guid: _randomGuid);

            (await _dataHandler.ExecuteAsync(new DeleteUser(_randomGuid))).ShouldBe(1);
        }

        [Test]
        public async Task DeleteUser_Given_UserIsDeleted_Should_RemoveRecord()
        {
            await InsertUser(guid: _randomGuid);

            (await Fetch<UserDTO>($"SELECT * FROM [User] where Guid = '{_randomGuid}'")).ShouldNotBeNull();

            await _dataHandler.ExecuteAsync(new DeleteUser(_randomGuid));

            (await Fetch<UserDTO>($"SELECT * FROM [User] where Guid = '{_randomGuid}'")).ShouldBeNull();
        }
    }
}
