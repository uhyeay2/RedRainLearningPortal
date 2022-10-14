using RedRainLearningPortal.Mediator.Handlers.UserHandlers;

namespace RedRainLearningPortal.Mediator.Tests.HandlerTests.UserHandlerTests
{
    internal class IsEmailRegisteredHandlerTests : BaseDataHandlerTest
    {
        protected readonly IsEmailRegisteredHandler _handler;

        public IsEmailRegisteredHandlerTests()
        {
            _handler = new(_mockDataHandler.Object, _mapper);
        }

        //TODO: Set up tests

    }
}
