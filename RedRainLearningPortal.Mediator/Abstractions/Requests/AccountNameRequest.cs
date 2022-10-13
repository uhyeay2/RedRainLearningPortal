namespace RedRainLearningPortal.Mediator.Abstractions.Requests
{
    public class AccountNameRequest : BaseValidatableRequest
    {
        public string? AccountName { get; set; }

        public override bool IsValid(out string failedValidationMessage)
        {
            failedValidationMessage = string.Empty;

            if (string.IsNullOrEmpty(AccountName))
            {
                failedValidationMessage = "Validation Failed! AccountName is a required field!";
                return false;
            }
            return true;
        }
    }
}
