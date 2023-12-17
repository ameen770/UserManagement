using Microsoft.AspNetCore.Mvc;
using MediatR;
using UserManagement.Application.Features.Departments.Commands.Models;
using UserManagement.Application.Features.Departments.Queries.Models;
using UserManagement.Domain.AppMetaData;

namespace UserManagement.WebAPI.Controllers
{
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /api/Student/List?$orderby=Name
        [HttpGet(Router.DepartmentRouting.List)]
        public async Task<IActionResult> GetDepartmentsList()
        {
            var response = await _mediator.Send(new GetDepartmentsListQuery());
            return Ok(response);
        }

        // GET /api/Student/List/5
        [HttpGet(Router.DepartmentRouting.GetByID)]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetDepartmentByIdQuery(id));
            return Ok(response);
        }

        [HttpPost(Router.DepartmentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddDepartmentCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
            //return NewResult(response);
        }

        [HttpPut(Router.DepartmentRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditDepartmentCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete(Router.DepartmentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new DeleteDepartmentCommand(id)));
        }
    }
}
