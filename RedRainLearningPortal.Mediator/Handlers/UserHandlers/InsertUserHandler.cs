using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;
using RedRainLearningPortal.Domain.Extensions;

namespace RedRainLearningPortal.Mediator.Handlers.UserHandlers
{
    public class InsertUserRequest : EmailBasedRequest
    {
        public string AccountName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public override bool IsValid(out List<string> validationErrors)
        {
            var isValid = base.IsValid(out validationErrors).StringsAreNotNullOrWhiteSpace(out var moreErrors, 
                (AccountName, nameof(AccountName)), (FirstName, nameof(FirstName)), (LastName, nameof(LastName)));

            validationErrors.AddRange(moreErrors);

            return isValid;
        }
    }

    internal class InsertUserHandler : BaseDataHandlerWithMediator<InsertUserRequest>
    {
        public InsertUserHandler(IDataHandler dataHandler, IMapper mapper, IMediator mediator) : base(dataHandler, mapper, mediator) { }

        internal override async Task<BaseResponse> HandleRequest(InsertUserRequest request, CancellationToken cancellationToken = default) =>
            await _dataHandler.ExecuteAsync(_mapper.Map<InsertUser>(request)) == 1 ? 
            Response.Success() : Response.AlreadyExists("User", $"Email: {request.Email} OR AccountName: {request.AccountName}");
    }
}
