using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Features.Users.Commands.Models;
using UserManagement.Application.Features.Users.Queries.Models;
using UserManagement.Domain.AppMetaData;

namespace UserManagement.WebAPI.Controllers
{
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /api/Users/List?$orderby=Name
        [HttpGet(Router.AppUserRouting.List)]
        public async Task<IActionResult> GetUsersList()
        {
            var response = await _mediator.Send(new GetUsersListQuery());
            return Ok(response);
        }

        // GET /api/Users/List/5
        [HttpGet(Router.AppUserRouting.GetByID)]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(response);
        }

        [HttpPost(Router.AppUserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
            //return NewResult(response);
        }

        [HttpPut(Router.AppUserRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete(Router.AppUserRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new DeleteUserCommand(id)));
        }
    }
}
