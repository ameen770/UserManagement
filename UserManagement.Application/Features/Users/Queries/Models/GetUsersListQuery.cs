using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.BasesHandlers;
using MediatR;
using UserManagement.Application.Features.Users.Queries.Results;

namespace UserManagement.Application.Features.Users.Queries.Models
{
    public class GetUsersListQuery : IRequest<Response<List<GetUsersListResponse>>>
    {
    }
}
