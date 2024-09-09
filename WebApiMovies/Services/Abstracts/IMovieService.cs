using System.Linq.Expressions;
using WebApiMovies.Entites;

namespace WebApiMovies.Services.Abstracts
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(Expression<Func<Movie, bool>> expression);
        Task Add(Movie entity);
        Task Delete(Movie entity);
    }
}
