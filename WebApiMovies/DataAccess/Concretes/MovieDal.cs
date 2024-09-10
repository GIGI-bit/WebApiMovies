using WebApiMovies.Data;
using WebApiMovies.DataAccess.Abstracts;
using WebApiMovies.Entites;
using WebApiMovies.Repositories.Concretes;

namespace WebApiMovies.DataAccess.Concretes
{
    public class MovieDal: EFRepository<Movie, MovieDBContext>, IMovieDal
    {
        public MovieDal(MovieDBContext movieDBContext):base(movieDBContext)
        {
        }
    }
}
