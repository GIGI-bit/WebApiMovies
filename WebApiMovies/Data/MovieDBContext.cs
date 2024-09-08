using Microsoft.EntityFrameworkCore;
using WebApiMovies.Entites;

namespace WebApiMovies.Data
{
    public class MovieDBContext:DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options)
        : base(options) { }

        DbSet<Movie> Movies {  get; set; }

    }
}
