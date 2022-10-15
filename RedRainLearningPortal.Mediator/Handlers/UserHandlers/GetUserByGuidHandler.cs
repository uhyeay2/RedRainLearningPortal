using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;
using RedRainLearningPortal.Domain.Models.Users;

namespace RedRainLearningPortal.Mediator.Handlers.UserHandlers
{
    public class GetUserByGuidRequest : GuidBasedRequest { }

    internal class GetUserByGuidHandler : BaseDataHandler<GetUserByGuidRequest>
    {
        public GetUserByGuidHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        internal override async Task<BaseResponse> HandleRequest(GetUserByGuidRequest request, CancellationToken cancellationToken = default)
        {
            var dto = await _dataHandler.FetchAsync<GetUserByGuid, UserDTO>(_mapper.Map<GetUserByGuid>(request));

            return dto != null ? Response.Success(_mapper.Map<User>(dto)) : Response.NotFound("User", $"Guid: {request.Guid}");
        }
    }
}
