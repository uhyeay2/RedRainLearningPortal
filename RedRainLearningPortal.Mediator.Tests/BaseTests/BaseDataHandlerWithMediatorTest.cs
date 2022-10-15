using MediatR;

namespace RedRainLearningPortal.Mediator.Tests.BaseTests
{
    public class BaseDataHandlerWithMediatorTest : BaseDataHandlerTest
    {
        protected Mock<IMediator> _mockMediator = new();
    }
}
