using System.Linq.Expressions;

namespace Institutional.Core.Repository.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task InsertAsync(T t);
        Task DeleteAsync(T t);
        Task UpdateAsync(T t);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ToListAsync();
        Task<List<T>> ToListByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
