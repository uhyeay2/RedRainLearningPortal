using RedRainLearningPortal.DataAccess.SqlGeneration.Attributes;

namespace RedRainLearningPortal.DataAccess.SqlGeneration.Attributes.FetchAttributes
{
    public class FetchableAttribute : SqlPropertyIdentiferAttribute
    {
        public FetchableAttribute()
        {
        }

        public FetchableAttribute(string specifiedDatabaseName) : base(specifiedDatabaseName)
        {
        }
    }
}
