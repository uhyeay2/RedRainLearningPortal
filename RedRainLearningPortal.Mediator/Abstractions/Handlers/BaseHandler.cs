using RedRainLearningPortal.Domain.Interfaces;

namespace RedRainLearningPortal.Mediator.Abstractions.Handlers
{
    internal abstract class BaseHandler<TRequest> : IRequestHandler<TRequest, IResponse> where TRequest : IRequest<IResponse>
    {
        internal abstract Task<IResponse> HandleRequest(TRequest request, CancellationToken cancellationToken = default);

        public async Task<IResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            Validate(request);

            return await HandleRequest(request, cancellationToken);
        }

        static void Validate(TRequest request)
        {
            if(request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage))
                throw new BadRequestException(failedValidationMessage);
        }
    }
}
