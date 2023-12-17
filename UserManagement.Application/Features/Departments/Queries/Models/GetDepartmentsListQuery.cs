using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.BasesHandlers;
using MediatR;
using UserManagement.Application.Features.Departments.Queries.Results;

namespace UserManagement.Application.Features.Departments.Queries.Models
{
    public class GetDepartmentsListQuery : IRequest<Response<List<GetDepartmentsListResponse>>>
    {
    }
}
