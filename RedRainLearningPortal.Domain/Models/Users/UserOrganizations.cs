using RedRainLearningPortal.Domain.Models.Organizations;

namespace RedRainLearningPortal.Domain.Models.Users
{
    public class UserOrganizations
    {
        public IEnumerable<Organization> OwnedOrganizations { get; set; } = Enumerable.Empty<Organization>();

        public IEnumerable<Organization> JoinedOrganizations { get; set; } = Enumerable.Empty<Organization>();
    }
}
