namespace RedRainLearningPortal.DataAccess.Models.DataTransferObjects.OrganizationDTOs
{
    [FetchQuery("OrganizationMember", "JOIN [User] WITH(NOLOCK) ON OrganizationMember.UserId = [User].Id", "OrganizationMember.OrganizationId = @Id")]
    public class OrganizationMemberDTO
    {
        [Fetchable]
        public int OrganizationMemberId { get; set; }

        [Fetchable("[User].Id")]
        public int UserId { get; set; }

        [Fetchable("[User].Guid")]
        public Guid UserIdentifier { get; set; }

        [Fetchable]
        public string Roles { get; set; } = string.Empty;

        [Fetchable]
        public string Email { get; set; } = null!;

        [Fetchable]
        public string AccountName { get; set; } = null!;

        [Fetchable]
        public string Name { get; set; } = null!;
    }
}
