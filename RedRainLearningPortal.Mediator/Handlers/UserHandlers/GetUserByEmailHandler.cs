using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;
using RedRainLearningPortal.Domain.Models.Users;

namespace RedRainLearningPortal.Mediator.Handlers.UserHandlers
{
    public class GetUserByEmailRequest : EmailBasedRequest { }

    internal class GetUserByEmailHandler : BaseDataHandler<GetUserByEmailRequest>
    {
        public GetUserByEmailHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        internal override async Task<BaseResponse> HandleRequest(GetUserByEmailRequest request, CancellationToken cancellationToken = default)
        {
            var dto = await _dataHandler.FetchAsync<GetUserByEmailOrAccountName, UserDTO>(_mapper.Map<GetUserByEmailOrAccountName>(request));

            return dto != null ? Response.Success(_mapper.Map<User>(dto)) : Response.NotFound("User", $"Email: {request.Email}");
        }
    }
}
