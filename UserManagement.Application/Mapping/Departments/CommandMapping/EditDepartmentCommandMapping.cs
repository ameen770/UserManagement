using UserManagement.Application.Features.Departments.Commands.Models;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void EditDepartmentCommandMapping()
        {
            CreateMap<EditDepartmentCommand, Department>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
