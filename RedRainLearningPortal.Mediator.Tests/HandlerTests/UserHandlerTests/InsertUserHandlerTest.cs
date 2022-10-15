using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;
using RedRainLearningPortal.Mediator.Handlers.UserHandlers;

namespace RedRainLearningPortal.Mediator.Tests.HandlerTests.UserHandlerTests
{
    internal class InsertUserHandlerTest : BaseDataHandlerWithMediatorTest
    {
        private InsertUserHandler Handler => new(_mockDataHandler.Object, _mapper, _mockMediator.Object);

        private static InsertUserRequest Request => new()
        {
            AccountName = "TestAccountName",
            Email = "JohnDoe@TestAccountName.Com",
            FirstName = "John",
            LastName = "Doe",
        };

        [Test]
        public async Task InsertUser_Given_ExecutionReturnsOne_ShouldReturn_SuccessResponse()
        {
            _mockDataHandler.Setup(_ => _.ExecuteAsync(It.IsAny<InsertUser>())).Returns(Task.FromResult(1));

            var response = await Handler.Handle(Request, default);

            response.Success.ShouldBeTrue();
            response.StatusCode.ShouldBe(200);
            response.Message.ShouldBe("Success");
        }

        [Test]
        public async Task InsertUser_Given_ExecutionDoesNotReturnOne_ShouldReturn_AlreadyExistsResponse()
        {
            _mockDataHandler.Setup(_ => _.ExecuteAsync(It.IsAny<InsertUser>())).Returns(Task.FromResult(0));

            var response = await Handler.Handle(Request, default);

            response.Success.ShouldBeFalse();
            response.StatusCode.ShouldBe(409);
            response.Message.ShouldContain("already exists");
            response.Message.ShouldContain(Request.Email);
            response.Message.ShouldContain(Request.AccountName);
        }

        public static readonly object[] InvalidEmailTestCases = 
        {
            "", "     ", "invalid", "email@", "invalid.Email", "@Email.Invalid", "MustContain@SomethingDotSomething",
        };

        [Test, TestCaseSource(nameof(InvalidEmailTestCases))]
        public async Task InsertUser_Given_InvalidEmail_ShouldThrow_BadRequest(string invalidEmail)
        {
            var request = Request;

            request.Email = invalidEmail;
            
            await Should.ThrowAsync<RequestValidationException>(async () => await Handler.Handle(request, default));
        }
    }
}
