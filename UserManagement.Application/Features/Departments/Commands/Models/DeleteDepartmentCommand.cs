using MediatR;
using UserManagement.Application.BasesHandlers;

namespace UserManagement.Application.Features.Departments.Commands.Models
{
    public class DeleteDepartmentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteDepartmentCommand(int id)
        {
            Id=id;
        }
    }
}
