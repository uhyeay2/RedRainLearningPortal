namespace RedRainLearningPortal.DataAccess.Models.DataTransferObjects
{
    [FetchQuery("Organization WITH(NOLOCK)", "Guid = @Guid")]
    public class OrganizationDTO
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
        public string Name { get; set; } = null!;
        
        [Fetchable]
        public string? Description { get; set; }
    }
}
