using MediatR;
using Microsoft.AspNetCore.Mvc;
using RedRainLearningPortal.Mediator.Abstractions.Responses;
using RedRainLearningPortal.Mediator.Handlers.UserHandlers;

namespace RedRainLearningPortal.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) => _mediator = mediator;

        #region Get 

        [HttpGet("getByAccountName")]
        public async Task<IResponse> GetByAccountNameAsync(string accountName) => await _mediator.Send(new GetUserByAccountNameRequest() { AccountName = accountName });

        [HttpGet("getByEmail")]
        public async Task<IResponse> GetByEmailAsync(string email) => await _mediator.Send(new GetUserByEmailRequest() { Email = email });

        [HttpGet("getByGuid")]
        public async Task<IResponse> GetByGuidAsync(Guid guid) => await _mediator.Send(new GetUserByGuidRequest() { Guid = guid });

        #endregion

        #region Is Exists

        [HttpGet("isEmailRegistered")]
        public async Task<IResponse> IsEmailRegisteredAsync(string email) => await _mediator.Send(new IsEmailRegisteredRequest() { Email = email });

        [HttpGet("isAccountNameTaken")]
        public async Task<IResponse> IsAccountNameTakenAsync(string accountName) => await _mediator.Send(new IsAccountNameTakenRequest() { AccountName = accountName });

        #endregion

        #region Insert / Delete

        [HttpPost("insert")]
        public async Task<IResponse> InsertAsync(InsertUserRequest request) => await _mediator.Send(request);

        [HttpPost("delete")]
        public async Task<IResponse> DeleteAsync(Guid guid) => await _mediator.Send(new DeleteUserRequest() { Guid = guid });

        #endregion

    }
}
