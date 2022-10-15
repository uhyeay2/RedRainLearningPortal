using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;
using RedRainLearningPortal.Mediator.Handlers.UserHandlers;

namespace RedRainLearningPortal.Mediator.Tests.HandlerTests.UserHandlerTests
{
    internal class DeleteUserHandlerTest : BaseDataHandlerTest
    {
        private readonly DeleteUserHandler _hanlder;

        public DeleteUserHandlerTest()
        {
            _hanlder = new(_mockDataHandler.Object, _mapper);
        }

        [Test]
        public async Task DeleteUserHandler_Given_EmptyGuid_ShouldThrow_BadRequest() => await Should
            .ThrowAsync<RequestValidationException>(async () => await _hanlder.Handle(new() { Guid = Guid.Empty }, default));

        [Test]
        public async Task DeleteUserHandler_Given_ExecutionReturnsOne_ShouldReturn_SuccessResponse()
        {
            _mockDataHandler.Setup(_ => _.ExecuteAsync(It.IsAny<DeleteUser>())).Returns(Task.FromResult(1));

            var response = await _hanlder.Handle(new() { Guid = Guid.NewGuid() }, default);

            response.Success.ShouldBeTrue();
            response.StatusCode.ShouldBe(200);
            response.Message.ShouldBe("Success");
        }

        [Test]
        public async Task DeleteUserHandler_Given_ExecutionDoesNotReturnOne_ShouldReturn_NotFoundResponse()
        {
            _mockDataHandler.Setup(_ => _.ExecuteAsync(It.IsAny<DeleteUser>())).Returns(Task.FromResult(0));

            var guid = Guid.NewGuid();

            var response = await _hanlder.Handle(new() { Guid = guid }, default);

            response.Success.ShouldBeFalse();
            response.StatusCode.ShouldBe(404);
            response.Message.ShouldContain("not found");
            response.Message.ShouldContain(guid.ToString());
        }
    }
}
