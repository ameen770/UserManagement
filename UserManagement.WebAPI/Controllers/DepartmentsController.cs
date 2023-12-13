using MediatR;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Features.Departments.Queries.Models;
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
    }
}
