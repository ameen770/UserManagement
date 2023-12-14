using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Services;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Infrastructure.Services
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
        public async Task<Department> GetDepartmentByIds(int? id)
        {
            var department = await _departmentRepository.GetTableNoTracking()
                                                  .Where(d => d.Id.Equals(id))
                                                  .FirstOrDefaultAsync();
            return department;
        }

        public async Task<List<Department>> GetDepartmentsLists()
        {
            var department = await _departmentRepository.GetDepartmentsListAsync();
            return department;
        }
        #endregion
    }
}
