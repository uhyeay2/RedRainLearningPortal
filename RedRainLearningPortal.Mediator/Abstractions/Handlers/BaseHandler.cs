using RedRainLearningPortal.Domain.Interfaces;

namespace RedRainLearningPortal.Mediator.Abstractions.Handlers
{
    internal abstract class BaseHandler<TRequest> : IRequestHandler<TRequest, BaseResponse> where TRequest : IRequest<BaseResponse>
    {
        internal abstract Task<BaseResponse> HandleRequest(TRequest request, CancellationToken cancellationToken = default);

        public async Task<BaseResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            Validate(request);

            return await HandleRequest(request, cancellationToken);
        }

        static void Validate(TRequest request)
        {
            if(request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage))
                throw new RequestValidationException(failedValidationMessage);
        }
    }
}
