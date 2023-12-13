using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Context;
using UserManagement.Infrastructure.GenericRepo;

namespace UserManagement.Infrastructure.Repositories
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        #region Fields
        private readonly DbSet<AppUser> _appUser;
        #endregion

        #region Constructors
        public AppUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _appUser = dbContext.Set<AppUser>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<AppUser>> GetUsersListAsync()
        {
            return await _appUser.Include(x => x.Department).ToListAsync();
        }
        #endregion
    }
}
