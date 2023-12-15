using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Features.Departments.Commands.Models;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void AddDepartmentCommandMapping()
        {
            CreateMap<AddDepartmentCommand, Department>()
               //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
