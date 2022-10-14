using RedRainLearningPortal.DataAccess.Models.Requests.UserRequests;
using RedRainLearningPortal.Mediator.Handlers.UserHandlers;

namespace RedRainLearningPortal.Mediator.Tests.HandlerTests.UserHandlerTests
{
    internal class InsertUserHandlerTest : BaseDataHandlerTest
    {
        private readonly InsertUserHandler _handler;

        private InsertUserRequest _request;

        public InsertUserHandlerTest()
        {
            _handler = new(_mockDataHandler.Object, _mapper);
        }

        [SetUp]
        public void Setup()
        {
            _request = new()
            {
                AccountName = "AccountName",
                Email = "Email@Email.com",
                Name = "Test Name"
            };
        }

        [Test]
        public async Task InsertUser_Given_ExecutionReturnsOne_ShouldReturn_SuccessResponse()
        {
            _mockDataHandler.Setup(_ => _.ExecuteAsync(It.IsAny<InsertUser>())).Returns(Task.FromResult(1));

            var response = await _handler.Handle(_request, default);

            response.Success.ShouldBeTrue();
            response.StatusCode.ShouldBe(200);
            response.Message.ShouldBe("Success");
        }

        [Test]
        public async Task InsertUser_Given_ExecutionDoesNotReturnOne_ShouldReturn_AlreadyExistsResponse()
        {
            _mockDataHandler.Setup(_ => _.ExecuteAsync(It.IsAny<InsertUser>())).Returns(Task.FromResult(0));

            var response = await _handler.Handle(_request, default);

            response.Success.ShouldBeFalse();
            response.StatusCode.ShouldBe(409);
            response.Message.ShouldContain("already exists");
            response.Message.ShouldContain(_request.Email);
            response.Message.ShouldContain(_request.AccountName);
        }

        public static readonly object[] InvalidEmailTestCases = 
        {
            "", "     ", "invalid", "email@", 
            "MustContain@SomethingDotSomething",
            "invalid.Email", "@Email.Invalid"
        };

        [Test, TestCaseSource(nameof(InvalidEmailTestCases))]
        public async Task InsertUser_Given_InvalidEmail_ShouldThrow_BadRequest(string invalidEmail)
        {
            _request.Email = invalidEmail;
            
            await Should.ThrowAsync<BadRequestException>(async () => await _handler.Handle(_request, default));
        }
    }
}
