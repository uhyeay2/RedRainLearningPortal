using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;

namespace RedRainLearningPortal.Mediator.Handlers.UserHandlers
{
    public class IsEmailRegisteredRequest : EmailBasedRequest { }

    internal class IsEmailRegisteredHandler : BaseDataHandler<IsEmailRegisteredRequest>
    {
        public IsEmailRegisteredHandler(IDataHandler dataHandler, IMapper mapper) : base(dataHandler, mapper) { }

        internal override async Task<BaseResponse> HandleRequest(IsEmailRegisteredRequest request, CancellationToken cancellationToken = default) =>
            Response.Success(await _dataHandler.FetchAsync<IsEmailRegistered, bool>(_mapper.Map<IsEmailRegistered>(request)));
    }
}
