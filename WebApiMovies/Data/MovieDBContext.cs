using Microsoft.EntityFrameworkCore;
using WebApiMovies.Entites;

namespace WebApiMovies.Data
{
    public class MovieDBContext:DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasIndex(i => i.ResponseId).IsUnique();
        }

        DbSet<Movie> Movies {  get; set; }

    }
}
