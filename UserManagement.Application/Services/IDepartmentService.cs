using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;

namespace UserManagement.Application.Services
{
    public interface IDepartmentService
    {
        public Task<List<Department>> GetDepartmentsLists();
        public Task<Department> GetDepartmentByIds(int? id);
        public Task<string> AddAsync(Department department);
        public Task<bool> IsNameArExist(string name);
        public Task<string> EditAsync(Department department);
        public Task<bool> IsNameArExistExcludeSelf(string name, int id);
        public Task<string> DeleteAsync(Department department);
    }
}
