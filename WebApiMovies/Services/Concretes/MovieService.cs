using WebApiMovies.Data;
using RestSharp;
using WebApiMovies.Services.Abstracts;
using WebApiMovies.Entites;
using System.Linq.Expressions;
using WebApiMovies.DataAccess.Abstracts;

namespace WebApiMovies.Services.Concretes
{
    public class MovieService:IMovieService
    {
        private readonly IMovieDal _movieDal;

        public MovieService(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public async Task Add(Movie entity)
        {
            await _movieDal.Add(entity);
        }

        public Task Delete(Movie entity)
        {
            throw new NotImplementedException();
        }

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
