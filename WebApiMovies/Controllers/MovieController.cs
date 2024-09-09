using Microsoft.AspNetCore.Mvc;
using WebApiMovies.Model;
using WebApiMovies.Services.Abstracts;

namespace WebApiMovies.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await movieService.GetAllAsync();
            var model = new MovieListViewModel()
            {
                Movies=list,
            };
            return View(model);
        }
    }
}
