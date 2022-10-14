using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;

namespace RedRainLearningPortal.Mediator.Handlers.UserHandlers
{
    public class GetUserByAccountNameRequest : AccountNameRequest { }

    internal class GetUserByAccountNameHandler : BaseDataHandler<GetUserByAccountNameRequest>
    {
        public GetUserByAccountNameHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        internal override async Task<IResponse> HandleRequest(GetUserByAccountNameRequest request, CancellationToken cancellationToken = default)
        {
            var dto = await _dataHandler.FetchAsync<GetUserByEmailOrAccountName, UserDTO>(_mapper.Map<GetUserByEmailOrAccountName>(request));

            return dto != null ? Response.Success(_mapper.Map<User>(dto)) : Response.NotFound("User", $"AccountName: {request.AccountName}");
        }
    }
}
