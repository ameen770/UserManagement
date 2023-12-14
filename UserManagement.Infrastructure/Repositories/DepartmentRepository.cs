using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;
using UserManagement.Infrastructure.Context;
using UserManagement.Infrastructure.GenericRepo;

namespace UserManagement.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        #region Fields
        private readonly DbSet<Department> _department;
        // private readonly IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructors
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _department = dbContext.Set<Department>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<Department>> GetDepartmentsListAsync()
        {
            return await _department.ToListAsync();
        }
        #endregion
    }
}
