using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;

namespace RedRainLearningPortal.Mediator.Handlers.UserHandlers
{
    public class InsertUserRequest : EmailBasedRequest
    {
        public string AccountName { get; set; } = string.Empty;

        public string? Name { get; set; }

        public override bool IsValid(out string failedValidationMessage)
        {
            var isValid = base.IsValid(out failedValidationMessage);

            if(string.IsNullOrWhiteSpace(AccountName))
            {
                failedValidationMessage += " Failed Validation - AccountName field is required!";
                return false;
            }

            return isValid;
        }
    }

    internal class InsertUserHandler : BaseDataHandler<InsertUserRequest>
    {
        public InsertUserHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        internal override async Task<IResponse> HandleRequest(InsertUserRequest request, CancellationToken cancellationToken = default)
        {
            return await _dataHandler.ExecuteAsync(_mapper.Map<InsertUser>(request)) == 1 ?
                new SuccessResponse() : BaseResponse.Conflict("An account already exists with the Email or AccountName provided.");
        }
    }
}
