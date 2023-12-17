using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Services
{
    public interface IAppUserService
    {
        public Task<List<AppUser>> GetUsersLists();
        public Task<AppUser> GetUserByIds(int? id);
        public Task<string> AddAsync(AppUser appUser);
        public Task<bool> IsEmailExist(string email);
        public Task<string> EditAsync(AppUser appUser);
        public Task<bool> IsEmailExistExcludeSelf(string email, int id);
        public Task<string> DeleteAsync(AppUser appUser);
    }
}
