using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;

namespace RedRainLearningPortal.Mediator.Handlers.UserHandlers
{
    public class DeleteUserRequest : GuidBasedRequest { }

    internal class DeleteUserHandler : BaseDataHandler<DeleteUserRequest>
    {
        public DeleteUserHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        internal override async Task<IResponse> HandleRequest(DeleteUserRequest request, CancellationToken cancellationToken = default)
        {
            return await _dataHandler.ExecuteAsync(_mapper.Map<DeleteUser>(request)) == 1 ? 
                Response.Success() : Response.NotFound("User", $"Guid: {request.Guid}");
        }
    }
}
