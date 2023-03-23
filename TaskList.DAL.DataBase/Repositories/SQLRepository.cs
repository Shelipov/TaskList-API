using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TaskList.DAL.Interface.Repositories;
using System.Linq.Expressions;

namespace TaskList.DAL.DataBase.Repositories
{
    public class SQLRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext dbContext;
        protected readonly DbSet<T> dbSet;

        public SQLRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> criteria)
        {
            return dbSet.FirstOrDefaultAsync(criteria);
        }

        public ValueTask<T> GetByIdAsync(Guid id)
        {
            return dbSet.FindAsync(id);
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> criteria, int skip = 0, int take = 0)
        {
            if (take > 0)
            {
                return dbSet.Where(criteria).Skip(skip).Take(take);
            }

            return dbSet.Where(criteria);
        }

        public IQueryable<T> Query(int skip = 0, int take = 0)
        {
            if (take > 0)
            {
                return dbSet.Skip(skip).Take(take);
            }

            return dbSet;
        }

        public async Task<T> AddAsync(T entity)
        {
            var e = await dbSet.AddAsync(entity);
            return e.Entity;
        }

        public Task AddAsync(IEnumerable<T> entities)
        {
            return dbSet.AddRangeAsync(entities);
        }

        
        public T Update(T entity)
        {
            dbSet.Update(entity);
            return entity;
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
                Remove(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public virtual Task SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
