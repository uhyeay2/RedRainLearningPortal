namespace RedRainLearningPortal.DataAccess.Models.DataTransferObjects.OrganizationDTOs
{
    [FetchQuery("Organization WITH(NOLOCK)", 
        join: "JOIN [User] WITH(NOLOCK) ON [User].Id = Organization.OwningUserId",
        where: "Organization.Guid = @Guid"
        )]
    public class OrganizationDTO
    {
        [Fetchable("Organization.Id")]
        public int Id { get; set; }

        [Fetchable("Organization.Guid")]
        public Guid Identifier { get; set; }

        [Fetchable("Organization.Name")]
        public string OrganizationName { get; set; } = null!;

        [Fetchable("[User].Name")]
        public string OwnerName { get; set; } = null!;

        [Fetchable("[User].AccountName")]
        public string OwnerAccountName { get; set; } = null!;

        [Fetchable("[User].Email")]
        public string OwnerEmail { get; set; } = null!;

        [Fetchable("[User].Guid")]
        public Guid OwnerIdentifier { get; set; }
    }
}
