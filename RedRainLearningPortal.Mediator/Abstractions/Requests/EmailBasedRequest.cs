using RedRainLearningPortal.Domain.Extensions;

namespace RedRainLearningPortal.Mediator.Abstractions.Requests
{
    public abstract class EmailBasedRequest : BaseValidatableRequest
    {
        public string Email { get; set; } = string.Empty;

        public override bool IsValid(out List<string> validationErrors)
        {
            validationErrors = new();

            if (!Email.IsValidEmailFormat())
            {
                validationErrors.Add("Email provided was not a valid email format! Email received: " + Email);
                return false;
            }
            return true;
        }
    }
}
