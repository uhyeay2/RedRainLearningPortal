using RedRainLearningPortal.DataAccess.Models.Requests.OrganizationRequests;

namespace RedRainLearningPortal.DataAccess.Tests.OrganizationTests
{
    public class GetOrganizationByGuidTests : BaseTest
    {
        [Test]
        public async Task GetOrganizationByGuid_Given_NoOrganizationWithGuid_Should_ReturnNull() =>
            (await _dataHandler.FetchAsync<GetOrganizationByGuid, OrganizationDTO>(new(_randomGuid))).ShouldBeNull();

        [Test]
        public async Task GetOrganizationByGuid_Given_OrganizationExistsWithGuid_Should_ReturnOrganization()
        {
            await SeedOrganization(_randomGuid, _testOrganization.Name, _testOrganization.Description);

            var dto = await _dataHandler.FetchAsync<GetOrganizationByGuid, OrganizationDTO>(new(_randomGuid));

            dto.ShouldNotBeNull();

            Assert.Multiple( () => {
                
                dto.Identifier.ShouldBe(_randomGuid);
                dto.Name.ShouldBe(_testOrganization.Name);
                dto.Description.ShouldBe(_testOrganization.Description);
            
            });
        }
    }
}
