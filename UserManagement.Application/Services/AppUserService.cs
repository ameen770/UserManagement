using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.IServices;
using UserManagement.Domain.Entities;
using UserManagement.Application.Interfaces;

namespace UserManagement.Infrastructure.Services
{
    public class AppUserService : IAppUserService
    {
        #region Fields
        private readonly IAppUserRepository _appUserRepository;
        #endregion

        #region Constractors
        public AppUserService(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }
        #endregion

        #region Handles Functions
        public async Task<List<AppUser>> GetUsersLists()
        {
            var appUser = await _appUserRepository.GetUsersListAsync();
            return appUser;
        }

        public async Task<AppUser> GetUserByIds(int? id)
        {
            var appUser = await _appUserRepository.GetTableNoTracking()//.Include(d => d.Department)
                                                  .Where(d => d.Id.Equals(id))
                                                  .FirstOrDefaultAsync();
            return appUser;
        }

        public async Task<string> AddAsync(AppUser appUser)
        {
            await _appUserRepository.AddAsync(appUser);
            return "Success";
        }

        public async Task<bool> IsEmailExist(string email)
        {
            //Check if the email is Exist Or not
            var appUser = _appUserRepository.GetTableNoTracking().Where(x => x.Email.Equals(email)).FirstOrDefault();
            if (appUser == null) return false;
            return true;
        }

        public async Task<string> EditAsync(AppUser appUser)
        {
            await _appUserRepository.UpdateAsync(appUser);
            return "Success";
        }

        public async Task<bool> IsEmailExistExcludeSelf(string email, int id)
        {
            //Check if the email is Exist Or not
            var appUser = await _appUserRepository.GetTableNoTracking().Where(x => x.Email.Equals(email) & !x.Id.Equals(id)).FirstOrDefaultAsync();
            if (appUser == null) return false;
            return true;
        }

        public async Task<string> DeleteAsync(AppUser appUser)
        {
            var trans = _appUserRepository.BeginTransaction();
            try
            {
                await _appUserRepository.DeleteAsync(appUser);
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.Message);
                return "Falied";
            }

        }
        #endregion
    }
}
