using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;
using UserManagement.Application.IGenericRepo;

namespace UserManagement.Application.Interfaces
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
        public Task<List<AppUser>> GetUsersListAsync();
    }
}
