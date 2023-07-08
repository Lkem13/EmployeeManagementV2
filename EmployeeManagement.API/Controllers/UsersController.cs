using EmployeeManagement.Application.CQRS.Positions.Requests.Commands;
using EmployeeManagement.Application.CQRS.Users.Requests.Commands;
using EmployeeManagement.Application.CQRS.Users.Requests.Queries;
using EmployeeManagement.Application.DataTransferObject.Position;
using EmployeeManagement.Application.DataTransferObject.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var users = await _mediator.Send(new GetUserListRequest());
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var user = await _mediator.Send(new GetUserDetailRequest { Id = id });
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUserDTO user)
        {
            var command = new CreateUserCommand { UserDTO = user };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateUserDTO user)
        {
            var command = new UpdateUserCommand { Id = id, UserDTO = user };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
