namespace RedRainLearningPortal.DataAccess.Models.DataTransferObjects.OrganizationDTOs
{
    public class OrganizationActionDTO
    {
        public int Id { get; set; }

        public string ActionName { get; set; } = null!;

        public string ActionTag { get; set; } = null!;
    }
}
