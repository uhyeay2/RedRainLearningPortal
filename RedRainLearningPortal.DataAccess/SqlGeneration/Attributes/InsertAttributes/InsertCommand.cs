namespace RedRainLearningPortal.DataAccess.SqlGeneration.Attributes.InsertAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InsertCommand : SqlScriptAttribute
    {
        public InsertCommand(string table) : base(table)
        {
        }

        public InsertCommand(string table, string from, string where) : base(table, where)
        {
            From = from;
        }


        public InsertCommand(string table, string ifNotExists) : base(table)
        {
            IfNotExists = ifNotExists;
        }

        public string IfNotExists { get; set; } = string.Empty;

        public bool IsInsertSelectRequest => !string.IsNullOrWhiteSpace(From);

        public string From { get; set; } = string.Empty;

        public string Join { get; set; } = string.Empty;

        public string GetValuesToInsert(string values) => IsInsertSelectRequest ? $"SELECT {values} FROM {From} {Join} {Where} " : $"VALUES ( {values} )";
    }
}
