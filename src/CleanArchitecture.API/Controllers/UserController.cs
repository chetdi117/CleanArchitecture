using CleanArchitecture.API.Extensions;
using CleanArchitecture.Application.Factory;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.UseCases.Commands.UserCommands.Create;
using CleanArchitecture.Application.UseCases.Commands.UserCommands.Delete;
using CleanArchitecture.Application.UseCases.Commands.UserCommands.Update;
using CleanArchitecture.Application.UseCases.Queries.UserQueries.GetUsersQueries;
using CleanArchitecture.Domain.Entities.User;
using CleanArchitecture.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Optional;
namespace CleanArchitecture.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("users")]
        [ProducesResponseType(typeof(BaseApiResponse<List<UserDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _mediator.Send(new GetUsersQuery(new GetUsersRequest()));
            return response.Users.Some().ToActionResult(response.Success, response.ErrorCode, response.Message);
        }

        [HttpPost("user")]
        [ProducesResponseType(typeof(BaseApiResponse<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CrateUser([FromForm] UserFormDTO form)
        {
            if(form == null)
            {
                return BadRequest("User form data is required.");
            }


            var response = await _mediator.Send(new CreateUserCommand(new CreateUserRequest()
            {
                Email = form.Email,
                FullName = form.FullName,
                Phone = form.Phone
            }));

            
            return Ok(ApplicationFactory.CreateSuccessResponse<string>(response.UserId));
        }

        [HttpPut("user/{id}")]
        [ProducesResponseType(typeof(BaseApiResponse<List<UserDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CrateUser(string id, [FromForm] UserFormDTO form)
        {
            if(string.IsNullOrEmpty(id))
            {
                return BadRequest("User ID cannot be null or empty.");
            }

            var response = await _mediator.Send(new UpdateUserCommand(id,new UpdateUserRequest()
            {
                Email = form.Email,
                FullName = form.FullName,
                Phone = form.Phone
            }));
          
            return response.Some().ToActionResult(response.Success, response.ErrorCode, response.Message);
        }



        [HttpDelete("user/{id}")]
        [ProducesResponseType(typeof(BaseApiResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("User ID cannot be null or empty.");
            }
            var response = await _mediator.Send(new DeleteUserCommand(new DeleteUserRequest(id)));
            return response.Some().ToActionResult(response.Success, response.ErrorCode, response.Message);
        }
    }
}
