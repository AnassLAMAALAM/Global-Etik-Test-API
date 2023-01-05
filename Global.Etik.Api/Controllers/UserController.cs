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

        /// <summary>
        /// Create a new user 
        /// </summary>
        /// <param name="create">user model</param>
        /// <returns>return user id</returns>
        [HttpPost("Create", Name = "AddUser")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserCommand create)
        {
            Guid id = await _mediator.Send(create);
            return Ok(id);
        }
        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="update">user model</param>
        /// <returns>return </returns>
        [HttpPut("Update", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateUserCommand update)
        {
             await _mediator.Send(update);
            return NoContent();
        }
        /// <summary>
        /// Delete a old user 
        /// </summary>
        /// <param name="id">id of given user to delete</param>
        /// <returns></returns>
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
        /// <summary>
        /// Get users list
        /// </summary>
        /// <returns>Users list</returns>
        [HttpGet("GetAll", Name = "ListUsers")]
        public async Task<ActionResult<List<ListUsersMV>>> GetAll()
        {
            var dtos = await _mediator.Send(new ListUsersQuery());
            return Ok(dtos);
        }
        /// <summary>
        /// Get a user with given id 
        /// </summary>
        /// <param name="id">Given id</param>
        /// <returns>return user</returns>
        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<UserMV>> GetById(Guid id)
        {
            var dtos = await _mediator.Send(new GetUserByIdQuery() { Id = id });
            return Ok(dtos);
        }
    }
}