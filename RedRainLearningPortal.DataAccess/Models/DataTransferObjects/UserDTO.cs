namespace RedRainLearningPortal.DataAccess.Models.DataTransferObjects
{
    [FetchQuery("[User] WITH(NOLOCK)", where: "Guid = @Guid")] 
    public class UserDTO
    {
        [Fetchable]
        public int Id { get; set; }

        [Fetchable("Guid")]
        public Guid Identifier { get; set; }

        [Fetchable]
        public DateTime CreatedAtDateTimeUTC { get; set; }

        [Fetchable]
        public DateTime? LastUpdatedDateTimeUTC { get; set; }

        [Fetchable]
        public string Email { get; set; } = null!;

        [Fetchable]
        public string AccountName { get; set; } = null!;

        [Fetchable]
        public string FirstName { get; set; } = null!;

        [Fetchable]
        public string LastName { get; set; } = null!;
    }
}
