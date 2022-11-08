namespace RedRainLearningPortal.DataAccess.Models.Requests.OrganizationRequests
{
    public class InsertOrganization : IRequestObject
    {
        public InsertOrganization()
        {
        }

        public InsertOrganization(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public object? GenerateParameters() => new { Name, Description };

        public string GenerateSql() => Insert.IfNotExistsCommand(
            selectionToNotExist: Fetch.Query(Tables.Organization_NoLock, where: "Name = @Name"),
            table: Tables.Organization,
            columnNames: "Name, Description",
            valueNames: "@Name, @Description");
    }
}
