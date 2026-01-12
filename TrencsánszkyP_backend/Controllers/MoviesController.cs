using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrencsánszkyP_backend.Models;

namespace TrencsánszkyP_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly CinemadbContext _context;
        public MoviesController(CinemadbContext context)
        {
            _context = context;
        }

        [HttpGet("feladat10")]
        public ActionResult GetAllMovies()
        {
            try 
            {
                var movies = _context.Movies
                .Select(m => new
                {
                    m.MovieId,
                    m.Title,
                    m.ReleaseDate,
                    m.ActorId,
                    m.FilmTypeId
                })
                .ToList();

                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            
        }


    }
}
