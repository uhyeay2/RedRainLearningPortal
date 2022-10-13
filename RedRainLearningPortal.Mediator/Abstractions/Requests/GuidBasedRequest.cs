namespace RedRainLearningPortal.Mediator.Abstractions.Requests
{
    public class GuidBasedRequest : BaseValidatableRequest
    {
        public Guid Guid { get; set; }

        public override bool IsValid(out string failedValidationMessage)
        {
            failedValidationMessage = string.Empty;

            if(Guid == Guid.Empty)
            {
                failedValidationMessage = "Validation Failed! Guid is a required Field";
                return false; 
            }
            return true;
        }
    }
}
