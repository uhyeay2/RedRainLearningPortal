using RedRainLearningPortal.Domain.Interfaces;

namespace RedRainLearningPortal.Mediator.Abstractions.Requests
{
    public abstract class BaseRequest : IMediatorRequest<IResponse> { }

    public abstract class BaseValidatableRequest : BaseRequest, IValidatable
    {
        public abstract bool IsValid(out string failedValidationMessage);
    }

    public interface IMediatorRequest<IResponse> : IRequest<IResponse> { }
}
