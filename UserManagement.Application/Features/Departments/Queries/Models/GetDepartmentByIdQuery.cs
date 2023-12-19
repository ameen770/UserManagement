using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.BasesHandlers;
using UserManagement.Application.Features.Departments.Queries.Results;

namespace UserManagement.Application.Features.Departments.Queries.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetSingleDepartmentResponse>>
    {
        public int Id { get; set; }

        public GetDepartmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
