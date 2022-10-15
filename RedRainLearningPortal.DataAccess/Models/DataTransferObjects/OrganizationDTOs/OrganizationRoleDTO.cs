namespace RedRainLearningPortal.DataAccess.Models.DataTransferObjects.OrganizationDTOs
{
    [FetchQuery("OrganizationRole", "OrganizationGuid = @Guid")]
    internal class OrganizationRoleDTO
    {
        public int Id { get; set; }

        public Guid Identifier { get; set; }

        public string RoleName { get; set; } = null!;

        public DateTime CreatedAtDateTimeUTC { get; set; }

        public DateTime? ExpiresAtDateTimeUTC { get; set; }

        public Guid OrganizationGuid { get; set; }
    }
}
