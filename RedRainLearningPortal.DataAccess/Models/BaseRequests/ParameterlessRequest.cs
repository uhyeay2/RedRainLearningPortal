using RedRainLearningPortal.DataAccess.Interfaces;

namespace RedRainLearningPortal.DataAccess.Models.BaseRequests
{
    public abstract class ParameterlessRequest : IRequestObject
    {
        public object? GenerateParameters() => null;

        public abstract string GenerateSql();
    }
}
