using System.Linq.Expressions;

namespace WebApiMovies.Repositories.Abstracts
{
    public interface IRepository<T>where T:class,new()
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> expression);
        Task Add(T entity);
        Task Delete(T entity);
    }
}
