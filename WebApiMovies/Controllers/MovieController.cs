using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebApiMovies.Entites;
using WebApiMovies.Model;
using WebApiMovies.Services.Abstracts;
using WebApiMovies.Services.Concretes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _movieService.GetAllAsync();
            var model = new MovieDto()
            {
                Movies = list,
            };
            return Ok(model);
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var valute = await _movieService.GetByIdAsync(entity => entity.Id == id );
            if (valute == null) return NotFound();
            await _movieService.Delete(valute);
            return Ok();
        }
    }
}
