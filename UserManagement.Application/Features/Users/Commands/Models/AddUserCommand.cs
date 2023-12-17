using MediatR;
using UserManagement.Application.BasesHandlers;

namespace UserManagement.Application.Features.Users.Commands.Models
{
    public class AddUserCommand : IRequest<Response<string>>
    {
        // public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public int DepartmentId { get; set; }

    }
}
