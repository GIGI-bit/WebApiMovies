using System.Linq.Expressions;
using WebApiMovies.Entites;
using WebApiMovies.Repositories.Abstracts;

namespace WebApiMovies.Repositories.Concretes
{
    public class MovieRepository : IMovieRepository
    {
        public Task<IEnumerable<Movie>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetByIdAsync(Expression<Func<Movie, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
