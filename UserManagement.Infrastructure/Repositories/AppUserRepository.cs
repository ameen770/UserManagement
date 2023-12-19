using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Application.Interfaces;
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
            return await _appUser.ToListAsync();
            //Include(x => x.Department).
        }
        #endregion
    }
}
