namespace RedRainLearningPortal.Mediator.Abstractions.Requests
{
    public class AccountNameRequest : BaseValidatableRequest
    {
        public string? AccountName { get; set; }

        public override bool IsValid(out List<string> validationErrors)
        {
            validationErrors = new();

            if (string.IsNullOrEmpty(AccountName))
            {
                validationErrors.Add("AccountName field cannot be Null/Empty/Whitespace!");
                return false;
            }
            return true;
        }
    }
}
