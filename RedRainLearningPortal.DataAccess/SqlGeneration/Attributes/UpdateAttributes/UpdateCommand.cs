namespace RedRainLearningPortal.DataAccess.SqlGeneration.Attributes.UpdateAttributes
{
    public class UpdateCommand : SqlScriptAttribute
    {
        public UpdateCommand(string table, string where) : base(table, where)
        {
        }
    }
}
