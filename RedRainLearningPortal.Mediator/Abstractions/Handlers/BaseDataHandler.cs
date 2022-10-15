namespace RedRainLearningPortal.Mediator.Abstractions.Handlers
{
    internal abstract class BaseDataHandler<TRequest> : BaseHandler<TRequest> where TRequest : IRequest<BaseResponse>
    {
        protected readonly IDataHandler _dataHandler;

        protected readonly IMapper _mapper;

        protected BaseDataHandler(IDataHandler dataHandler, IMapper mapper)
        {
            _dataHandler = dataHandler;
            _mapper = mapper;
        }
    }
}
