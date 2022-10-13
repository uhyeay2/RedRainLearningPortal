using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;

namespace RedRainLearningPortal.Mediator.Handlers.UserHandlers
{
    public class IsAccountNameTakenRequest : AccountNameRequest { }

    internal class IsAccountNameTakenHandler : BaseDataHandler<IsAccountNameTakenRequest>
    {
        public IsAccountNameTakenHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        internal override async Task<IResponse> HandleRequest(IsAccountNameTakenRequest request, CancellationToken cancellationToken = default)
        {
            return Response.Success(await _dataHandler.FetchAsync<IsAccountNameTaken, bool>(_mapper.Map<IsAccountNameTaken>(request)));
        }
    }
}
