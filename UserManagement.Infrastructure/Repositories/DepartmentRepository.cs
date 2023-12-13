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
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        #region Fields
        private readonly DbSet<Department> _department;
        private readonly IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructors
        public DepartmentRepository(ApplicationDbContext dbContext, IDepartmentRepository _epartmentRepository) : base(dbContext)
        {
            _department = dbContext.Set<Department>();
            _departmentRepository = _epartmentRepository;
        }
        #endregion

        #region Handles Functions
        public async Task<List<Department>> GetDepartmentsListAsync()
        {
            return await _department.ToListAsync();
        }
        

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            // var student = await _studentRepository.GetByIdAsync(id);
            var department = await _departmentRepository.GetTableNoTracking()
                                                  .Where(d => d.Id.Equals(id))
                                                  .FirstOrDefaultAsync();
            return department;
        }
        #endregion
    }
}
