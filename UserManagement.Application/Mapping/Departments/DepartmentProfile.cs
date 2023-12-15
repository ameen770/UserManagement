using AutoMapper;
using UserManagement.Application.Features.Departments.Queries.Results;
using UserManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetStudentListMapping();
            GetStudentByIdMapping();
            AddDepartmentCommandMapping();
            EditDepartmentCommandMapping();
        }
    }
}
