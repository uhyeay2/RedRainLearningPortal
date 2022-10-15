using RedRainLearningPortal.Domain.Models.Users;

namespace RedRainLearningPortal.Domain.Models.Organizations
{
    public class Organization
    {
        public Guid Identifier { get; set; }

        public string Name { get; set; } = null!;

        public User Owner { get; set; } = null!;

        public IEnumerable<User> Members { get; set; } = Enumerable.Empty<User>();
    }
}
