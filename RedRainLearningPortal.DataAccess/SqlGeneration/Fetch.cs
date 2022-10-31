namespace RedRainLearningPortal.DataAccess.SqlGeneration
{
    internal static class Fetch
    {
        #region Non-Reflection Sql Generation

        /// <summary> $"SELECT {columns} FROM {table} {join} WHERE {where}"; **WHERE is only added when where argument is not NullOrWhiteSpace</summary>
        public static string Query(string table, string columns = "*", string where = "", string join = "", string orderBy = "")
        {
            if (!string.IsNullOrWhiteSpace(where))
            {
                where = "WHERE " + where;
            }

            return $"SELECT {columns} FROM {table} {join} {where}";
        }


        /// <summary> Returns "SELECT CASE WHEN EXISTS(SELECT {column} FROM {table} WHERE {condition}) THEN 1 ELSE 0 END" </summary>
        public static string Exists(string table, string condition, string column = "*") => 
            $"SELECT CASE WHEN EXISTS(SELECT {column} FROM {table} WHERE {condition}) THEN 1 ELSE 0 END";

        #endregion

        #region Sql Generation w/ Reflection

        public static string ReflectionQuery<DTO>(string whereOverride = "")
        {
            if (Attribute.GetCustomAttribute(typeof(DTO), typeof(FetchQuery)) is not FetchQuery queryDetails)
            {
                throw new ApplicationException($"{nameof(DTO)} Must Contain The FetchQuery Attribute For SQL Generation.");
            }

            var propertyAttributes = typeof(DTO).GetSqlProperties<FetchableAttribute>();

            var itemsToSelect = !propertyAttributes.Any() ? "*" : propertyAttributes.Select(p =>
                    $"{p.Attribute.SpecifiedDatabaseNameOr(p.PropertyName)} as {p.PropertyName}").AggregateWithCommaNewLine();

            var where = !string.IsNullOrWhiteSpace(whereOverride) ? "WHERE " + whereOverride : queryDetails.Where;

            return $"SELECT {itemsToSelect} FROM {queryDetails.Table} {queryDetails.Joins} {where} {queryDetails.OrderBy}";
        }

        #endregion
    }
}
