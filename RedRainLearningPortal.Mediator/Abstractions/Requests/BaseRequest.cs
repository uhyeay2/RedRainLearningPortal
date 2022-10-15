using RedRainLearningPortal.Domain.Interfaces;

namespace RedRainLearningPortal.Mediator.Abstractions.Requests
{
    public abstract class BaseRequest : IRequest<BaseResponse> { }

    public abstract class BaseValidatableRequest : BaseRequest, IValidatable
    {
        public abstract bool IsValid(out List<string> validationErrors);
    }
}
