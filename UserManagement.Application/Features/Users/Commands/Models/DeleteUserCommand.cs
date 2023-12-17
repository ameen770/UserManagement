using MediatR;
using UserManagement.Application.BasesHandlers;

namespace UserManagement.Application.Features.Users.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteUserCommand(int id)
        {
            Id=id;
        }
    }
}
