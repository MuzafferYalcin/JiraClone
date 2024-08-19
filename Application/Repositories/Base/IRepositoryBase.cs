using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<bool> Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        DbSet<T> Table { get;}
        Task<List<T>> GetList(Expression<Func<T, bool>>? filter = null);
        Task<T?> Get(Expression<Func<T, bool>> filter);
        Task<int> SaveAsync();
    }
}