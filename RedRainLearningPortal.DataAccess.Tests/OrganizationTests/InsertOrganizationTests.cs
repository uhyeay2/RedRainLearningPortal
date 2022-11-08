using RedRainLearningPortal.DataAccess.Models.Requests.OrganizationRequests;

namespace RedRainLearningPortal.DataAccess.Tests.OrganizationTests
{
    public class InsertOrganizationTests : BaseTest
    {
        private InsertOrganization _testRequest => new(_testOrganization.Name, _testOrganization.Description!);

        [Test]
        public async Task InsertOrganization_Given_OrganizationIsInserted_Should_ReturnOne() => (await _dataHandler.ExecuteAsync(_testRequest)).ShouldBe(1);

        [Test]
        public async Task InsertOrganization_Given_OrganizationNameAlreadyExists_Should_ReturnNegativeOne()
        {
            await _dataHandler.ExecuteAsync(_testRequest);

            (await _dataHandler.ExecuteAsync(new InsertOrganization(_testOrganization.Name, "New Description"))).ShouldBe(-1);
        }
    }
}
