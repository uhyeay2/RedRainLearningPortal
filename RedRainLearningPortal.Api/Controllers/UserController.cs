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

        [HttpGet("getByEmail")]
        public async Task<IResponse> GetByEmailAsync(string email) => await _mediator.Send(new GetUserByEmailRequest() { Email = email });

        [HttpPost("insert")]
        public async Task<IResponse> InsertAsync(InsertUserRequest request) => await _mediator.Send(request);

        [HttpGet("isEmailRegistered")]
        public async Task<IResponse> IsEmailRegisteredAsync(string email) => await _mediator.Send(new IsEmailRegisteredRequest() { Email = email });


    }
}
