using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrencsánszkyP_backend.Models;

namespace TrencsánszkyP_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly CinemadbContext _context;
        public MoviesController(CinemadbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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
                return BadRequest(new
                {
                    hiba = ex.Message
                });
            }
        }

        [HttpPost("feladat13")]
        public IActionResult AddMovie([FromBody] AddNewDto m, [FromQuery] string uid)
        {
            try
            {
                var UID = _configuration["UID"];

                if (uid != UID)
                    return Unauthorized("Nincs jogosultság.");

                
                var newMovie = new Movie
                {
                    Title = m.Title,
                    ReleaseDate = m.ReleaseDate,
                    ActorId = m.ActorId,
                    FilmTypeId = m.FilmTypeId
                };

                _context.Movies.Add(newMovie);
                _context.SaveChanges();

                return StatusCode(201, new { message = "Film sikeresen hozzáadva."});
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    hiba = ex.Message
                });
            }
        }

        }
    }
