namespace RedRainLearningPortal.Mediator.Abstractions.Handlers
{
    internal abstract class BaseDataHandlerWithMediator<TRequest> : BaseDataHandler<TRequest> where TRequest : IRequest<BaseResponse>
    {
        protected readonly IMediator _mediator;

        protected BaseDataHandlerWithMediator(IDataHandler dataHandler, IMapper mapper, IMediator mediator) 
            : base(dataHandler, mapper) => _mediator = mediator;

        internal abstract override Task<BaseResponse> HandleRequest(TRequest request, CancellationToken cancellationToken = default);
    }
}
