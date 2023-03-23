using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.DAL.Interface.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> Query(Expression<Func<T, bool>> criteria, int skip = 0, int take = 0);
        IQueryable<T> Query(int skip = 0, int take = 0);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> criteria);
        ValueTask<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task AddAsync(IEnumerable<T> entities);
        T Update(T entity);
        Task RemoveAsync(Guid id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task SaveChangesAsync();
    }
}
