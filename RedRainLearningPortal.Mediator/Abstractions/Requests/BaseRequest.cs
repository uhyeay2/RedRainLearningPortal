namespace RedRainLearningPortal.Mediator.Abstractions.Requests
{
    public class BaseRequest : IMediatorRequest<IResponse> { }

    public interface IMediatorRequest<IResponse> : IRequest<IResponse> { }
}
