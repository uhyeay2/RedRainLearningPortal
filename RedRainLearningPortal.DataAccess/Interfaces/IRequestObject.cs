namespace RedRainLearningPortal.DataAccess.Interfaces
{
    public interface IRequestObject
    {
        public object? GenerateParameters();

        public string GenerateSql();
    }
}
