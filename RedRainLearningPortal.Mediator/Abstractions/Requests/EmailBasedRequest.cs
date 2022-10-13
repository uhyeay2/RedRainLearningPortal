using RedRainLearningPortal.Domain.Extensions;

namespace RedRainLearningPortal.Mediator.Abstractions.Requests
{
    public abstract class EmailBasedRequest : BaseValidatableRequest
    {
        public string Email { get; set; } = string.Empty;

        public override bool IsValid(out string failedValidationMessage)
        {
            failedValidationMessage = string.Empty;

            if(string.IsNullOrWhiteSpace(Email))
            {
                failedValidationMessage = "Validation Failed - Email field is required.";
                return false;
            }

            if (!Email.IsValidEmailFormat())
            {
                failedValidationMessage = "Validation Failed - Invalid Email Format";
                return false;
            }
            return true;
        }
    }
}
