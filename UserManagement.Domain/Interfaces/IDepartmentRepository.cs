using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;
using UserManagement.Domain.IGenericRepo;

namespace UserManagement.Domain.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        public Task<List<Department>> GetDepartmentsListAsync();
        // public Task<Department> GetDepartmentByIdAsync(int? id);
    }
}
