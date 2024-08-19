using System.Linq.Expressions;
using Application.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Context;

namespace Persistence.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly JiraDbContext _context;

        public RepositoryBase(JiraDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> Add(T entity)
        {
            EntityEntry entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public bool Delete(T entity)
        {
            EntityEntry entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool Update(T entity)
        {
            EntityEntry entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<T?> Get(Expression<Func<T, bool>> filter)
        {
            return await Table.Where(filter).SingleOrDefaultAsync();
        }

        public async Task<List<T>> GetList(Expression<Func<T, bool>>? filter = null)
        {
            return filter == null ?
                                await Table.ToListAsync() :
                                await Table.Where(filter).ToListAsync();
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    }
}