using AutoMapper;
using UserManagement.Application.Features.Users.Queries.Results;
using UserManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Mapping.Users
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            GetUsersListMapping();
            GetUserByIdMapping();
            AddUserCommandMapping();
            EditUserCommandMapping();
        }
    }
}
