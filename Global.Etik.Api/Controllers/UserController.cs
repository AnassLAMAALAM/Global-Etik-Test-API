using Global.Etik.Application.Features.Users.Commands.CreateUsers;
using Global.Etik.Application.Features.Users.Commands.DeleteUsers;
using Global.Etik.Application.Features.Users.Commands.UpdateUsers;
using Global.Etik.Application.Features.Users.Queries.GetUserById;
using Global.Etik.Application.Features.Users.Queries.ListUsers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Global.Etik.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserCommand create)
        {
            Guid id = await _mediator.Send(create);
            return Ok(id);
        }
        [HttpPut(Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> valid([FromBody] UpdateUserCommand update)
        {
            await _mediator.Send(update);
            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var delete = new DeleteUserCommand() { Id = id };
            await _mediator.Send(delete);
            return NoContent();
        }
        [HttpGet("GetAll", Name = "ListUsers")]
        public async Task<ActionResult<List<ListUsersMV>>> GetAll()
        {
            var dtos = await _mediator.Send(new ListUsersQuery());
            return Ok(dtos);
        }
        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<UserMV>> GetById(Guid id)
        {
            var dtos = await _mediator.Send(new GetUserByIdQuery() { Id = id });
            return Ok(dtos);
        }
    }
}
