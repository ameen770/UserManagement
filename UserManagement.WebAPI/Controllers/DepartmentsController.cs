using Microsoft.AspNetCore.Mvc;
using UserManagement.WebAPI.Base;
using MediatR;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http;
using UserManagement.Application.Features.Departments.Commands.Models;
using UserManagement.Application.Features.Departments.Queries.Models;
using Microsoft.AspNetCore.Authorization;
//using Router = UserManagement.Domain.AppMetaData.Router;

namespace UserManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /api/Student/List?$orderby=Name
        [HttpGet]
        // [EnableQuery]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new GetDepartmentListQuery());
            return Ok(response);
        }

        // GET /api/Student/List/5
        [HttpGet("/{id}")]
        //[HttpGet(Router.DepartmentRouting.GetByID)]
        // [EnableQuery]
        public async Task<IActionResult> GetStudentList([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetDepartmentByIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddDepartmentCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
            //return NewResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditDepartmentCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new DeleteDepartmentCommand(id)));
        }
    }
}
