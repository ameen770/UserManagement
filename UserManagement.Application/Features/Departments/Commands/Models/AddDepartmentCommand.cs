using MediatR;
using UserManagement.Application.BasesHandlers;

namespace UserManagement.Application.Features.Departments.Commands.Models
{
    public class AddDepartmentCommand : IRequest<Response<string>>
    {
        // public int Id { get; set; }
        public string Name { get; set; }
        
    }
}
