namespace RedRainLearningPortal.Domain.Interfaces
{
    public interface IValidatable
    {
        bool IsValid(out List<string> validationErrors);
    }
}
