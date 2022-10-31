﻿namespace RedRainLearningPortal.DataAccess.SqlGeneration
{
    internal static class Insert
    {
        #region Non-Reflection Sql Generation

        /// <summary> $"INSERT INTO {table} ( {columnNames} ) VALUES ( {valueNames} )"; </summary>
        internal static string Command(string table, string columnNames, string valueNames) =>
            $"INSERT INTO {table} ( {columnNames} ) VALUES ( {valueNames} )";

        /// <summary> $"INSERT INTO {table} ( {columnNames} ) SELECT {valueNames} FROM {from} {join} WHERE {where}"; </summary>
        internal static string SelectFromCommand(string table, string columnNames, string valueNames, string from, string where, string join = "") =>
            $"INSERT INTO {table} ( {columnNames} ) SELECT {valueNames} FROM {from} {join} WHERE {where}";

        /// <summary> $"IF NOT EXISTS ( {selectionToNotExist} ) BEGIN \n INSERT INTO {table} ( {columnNames} ) VALUES ( {valueNames} ) END"; </summary>
        internal static string IfNotExistsCommand(string selectionToNotExist, string table, string columnNames, string valueNames) =>
            $"IF NOT EXISTS ( {selectionToNotExist} ) BEGIN \n INSERT INTO {table} ( {columnNames} ) VALUES ( {valueNames} ) END";

        /// <summary> $"IF NOT EXISTS ( {selectionToNotExist} ) BEGIN \n INSERT INTO {table} ( {columnNames} ) SELECT {valueNames} FROM {from} {join} WHERE {where} END"; </summary>
        internal static string IfNotExistsSelectFromCommand(string selectionToNotExist, string table, string columnNames, string valueNames, string from, string where, string join = "") =>
            $"IF NOT EXISTS ( {selectionToNotExist} ) BEGIN \n INSERT INTO {table} ( {columnNames} ) SELECT {valueNames} FROM {from} {join} WHERE {where} END";

        #endregion

        #region Sql Generation w/ Reflection

        /// <summary>
        /// Uses reflection to return a string using a request object that uses the InsertCommand attribute
        /// </summary>
        internal static string ReflectionCommand<TRequest>()
        {
            if (Attribute.GetCustomAttributes(typeof(TRequest), typeof(InsertCommand)) is not InsertCommand[] requests || !requests.Any())
            {
                throw new ApplicationException($"{nameof(TRequest)} Must Contain The InsertQuery Attribute For SQL Generation.");
            }

            var propertyAttributes = typeof(TRequest).GetSqlProperties<InsertableAttribute>();

            if (!propertyAttributes.Any())
            {
                throw new ApplicationException($"Request Object {nameof(TRequest)} Must contain properties with the Insertable attribute.");
            }

            // An InsertRequestObject could have multiple InsertQuery Attributes - Transform each one
            var inserts = requests.Select(r =>
            {
                // Get the ColumnName to insert, and the value being inserted, from the propertyAttributes for the current insert
                IEnumerable<(string ColumnName, string ValueName)> items = propertyAttributes
                    .Where(p => p.Attribute.TableName == r.Table)
                        .Select(x => (
                            x.Attribute.SpecifiedDatabaseNameOr(x.PropertyName),
                            x.Attribute.ColumnNameToFetchOr(x.PropertyName))        
                        );

                // by default scopedIdentity will be empty string
                var declareAndSetScopedIdentity = string.Empty;

                // if this insert has a property that uses scoped identity
                if (propertyAttributes.Any(x => x.Attribute.TableName == r.Table && x.Attribute.UseScopedIdentity))
                {
                    var scopedProperty = propertyAttributes.FirstOrDefault(x => x.Attribute.TableName == r.Table && x.Attribute.UseScopedIdentity);

                    declareAndSetScopedIdentity = $"DECLARE @{scopedProperty.PropertyName} {scopedProperty.Attribute.SqlTypeName} = SCOPE_IDENTITY() ";
                }

                // Beginning of Insert, define the table and items being inserted. Aggregate items being inserted with CommaNewLine for increased readability
                var insertIntoTableColumns = $"INSERT INTO \n {r.Table} \n ( \n {items.Select(x => x.ColumnName).AggregateWithCommaNewLine()} \n ) ";

                // Values to insert will also be aggregated the same way
                var valuesToInsert = r.GetValuesToInsert(items.Select(v => v.ValueName).AggregateWithCommaNewLine());

                // If this request uses IfNotExist, then this is the beginning of the wrapper for the request.
                var beginInsertIfNotExists = string.IsNullOrWhiteSpace(r.IfNotExists) ? string.Empty : $"\n IF NOT EXISTS \n ( {r.IfNotExists} ) \n BEGIN \n";
                // if the request uses IfNotExist, then this is the end of the wrapper for the request
                var endInsertIfNotExists = string.IsNullOrWhiteSpace(r.IfNotExists) ? string.Empty : "\n END ";

                // return the insert request
                return $"{declareAndSetScopedIdentity} \n {beginInsertIfNotExists} {insertIntoTableColumns} {valuesToInsert} {endInsertIfNotExists}";

            }).Aggregate((a, b) => $"{a} \n \n {b}"); // Aggregate each InsertRequest on the class with new lines between them

            // wrap the return in a BEGIN TRANSACTION if using scoped identity 
            return propertyAttributes.Any(x => x.Attribute.UseScopedIdentity) ? $"BEGIN TRANSACTION \n {inserts} \n COMMIT TRANSACTION" : inserts;
        }

        #endregion
    }
}
