using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;

namespace RedRainLearningPortal.Mediator.Handlers.UserHandlers
{
    public class GetUserByGuidRequest : GuidBasedRequest { }

    internal class GetUserByGuidHandler : BaseDataHandler<GetUserByGuidRequest>
    {
        public GetUserByGuidHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        internal override async Task<IResponse> HandleRequest(GetUserByGuidRequest request, CancellationToken cancellationToken = default)
        {
            var dto = await _dataHandler.FetchAsync<GetUserByGuid, UserDTO>(_mapper.Map<GetUserByGuid>(request));

            return dto != null ? Response.Success(_mapper.Map<User>(dto)) : Response.NotFound("No user was found with the Guid: " + request.Guid);
        }
    }
}
