using RedRainLearningPortal.Domain.Extensions;
using RedRainLearningPortal.Domain.Interfaces;

namespace RedRainLearningPortal.Mediator.Abstractions.Requests
{
    public abstract class EmailBasedRequest : BaseRequest, IValidatable
    {
        protected EmailBasedRequest()
        {
        }

        public string Email { get; set; } = string.Empty;

        public virtual bool IsValid(out string failedValidationMessage)
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
