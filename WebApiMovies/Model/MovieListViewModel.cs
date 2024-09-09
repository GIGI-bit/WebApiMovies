using WebApiMovies.Entites;

namespace WebApiMovies.Model
{
    public class MovieListViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }

    }
}
