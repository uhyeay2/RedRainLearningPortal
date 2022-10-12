namespace RedRainLearningPortal.Domain.Models
{
    public class User
    {
        public Guid Identifier { get; set; }

        public string Email { get; set; } = null!;

        public string AccountName { get; set; } = null!;

        public string Name { get; set; } = null!;
    }
}
