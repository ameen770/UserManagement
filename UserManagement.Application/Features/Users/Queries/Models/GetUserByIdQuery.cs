using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.BasesHandlers;
using UserManagement.Application.Features.Users.Queries.Results;

namespace UserManagement.Application.Features.Users.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetSingleUserResponse>>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
