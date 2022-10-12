using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;

namespace RedRainLearningPortal.Mediator.Handlers.UserHandlers
{
    public class GetUserByEmailRequest : EmailBasedRequest { }

    internal class GetUserByEmailHandler : BaseDataHandler<GetUserByEmailRequest>
    {
        public GetUserByEmailHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        internal override async Task<IResponse> HandleRequest(GetUserByEmailRequest request, CancellationToken cancellationToken = default)
        {
            var dto = await _dataHandler.FetchAsync<GetUserByEmailOrAccountName, UserDTO>(_mapper.Map<GetUserByEmailOrAccountName>(request));

            return dto != null ? Response.Success(_mapper.Map<User>(dto)) : Response.NotFound("No user found with the email: " + request.Email);
        }
    }
}
