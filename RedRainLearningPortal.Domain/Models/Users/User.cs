namespace RedRainLearningPortal.Domain.Models.Users
{
    public class User
    {
        public Guid Identifier { get; set; }

        public string Email { get; set; } = null!;

        public string AccountName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public UserOrganizations Organizations { get; set; } = new UserOrganizations();
    }
}
