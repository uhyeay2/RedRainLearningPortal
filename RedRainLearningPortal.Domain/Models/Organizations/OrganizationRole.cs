using RedRainLearningPortal.Domain.Models.Users;

namespace RedRainLearningPortal.Domain.Models.Organizations
{
    public class OrganizationRole
    {
        public Guid OrganizationIdentifier { get; set; }

        public string RoleName { get; set; } = null!;

        public DateTime RoleStartDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public IEnumerable<UserAction> RoleCapabilities { get; set; } = Enumerable.Empty<UserAction>();
    }
}
