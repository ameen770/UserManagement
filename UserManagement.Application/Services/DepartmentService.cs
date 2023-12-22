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

namespace UserManagement.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        #endregion

        #region Constractors
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion

        #region Handles Functions
        public async Task<List<Department>> GetDepartmentsLists()
        {
            var department = await _departmentRepository.GetDepartmentsListAsync();
            return department;
        }

        public async Task<Department> GetDepartmentByIds(int? id)
        {
            var department = await _departmentRepository.GetTableNoTracking()
                                                  .Where(d => d.Id.Equals(id))
                                                  .FirstOrDefaultAsync();
            return department;
        }

        public async Task<string> AddAsync(Department department)
        {
            await _departmentRepository.AddAsync(department);
            return "Success";
        }

        public async Task<bool> IsNameExist(string name)
        {
            //Check if the name is Exist Or not
            var department = _departmentRepository.GetTableNoTracking().Where(x => x.Name.Equals(name)).FirstOrDefault();
            if (department == null) return false;
            return true;
        }

        public async Task<string> EditAsync(Department department)
        {
            await _departmentRepository.UpdateAsync(department);
            return "Success";
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            //Check if the name is Exist Or not
            var department = await _departmentRepository.GetTableNoTracking().Where(x => x.Name.Equals(name) & !x.Id.Equals(id)).FirstOrDefaultAsync();
            if (department == null) return false;
            return true;
        }

        public async Task<string> DeleteAsync(Department department)
        {
            var trans = _departmentRepository.BeginTransaction();
            try
            {
                await _departmentRepository.DeleteAsync(department);
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

        public async Task<bool> IsDepartmentIdExist(int departmentId)
        {
            return await _departmentRepository.GetTableNoTracking().AnyAsync(x => x.Id.Equals(departmentId));
        }
        #endregion
    }
}
