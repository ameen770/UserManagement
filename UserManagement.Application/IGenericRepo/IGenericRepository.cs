using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.IGenericRepo
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int? id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> GetTableNoTracking();
        IDbContextTransaction BeginTransaction();

        /*        IQueryable<T> GetTableAsTracking();


                Task DeleteRangeAsync(ICollection<T> entities);
                Task SaveChangesAsync();

                void Commit();
                void RollBack(); 
                Task AddRangeAsync(ICollection<T> entities);  
                Task UpdateRangeAsync(ICollection<T> entities);
                Task<IDbContextTransaction> BeginTransactionAsync();
                Task CommitAsync();
                Task RollBackAsync();*/
    }
}
