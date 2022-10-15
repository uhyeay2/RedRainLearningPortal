namespace RedRainLearningPortal.Mediator.Abstractions.Requests
{
    public class GuidBasedRequest : BaseValidatableRequest
    {
        public Guid Guid { get; set; }

        public override bool IsValid(out List<string> validationErrors)
        {
            validationErrors = new();

            if (Guid == Guid.Empty)
            {
                validationErrors.Add("Guid is a required Field! Guid received: " + Guid);
                return false; 
            }
            return true;
        }
    }
}
