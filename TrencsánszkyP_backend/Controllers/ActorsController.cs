using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrencsánszkyP_backend.Models;

namespace TrencsánszkyP_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {

        private readonly CinemadbContext _context;
        public ActorsController(CinemadbContext context)
        {
            _context = context;
        }

        [HttpGet("feladat9/{actor_name}")]
        public ActionResult GetActorWithBooks()
        {
            try
            {
                var actorName = HttpContext.Request.RouteValues["actor_name"]?.ToString();
                var actor = _context.Actors
                .Where(a => a.ActorName == actorName)
                .Select(a => new
                {
                    a.ActorId,
                    a.ActorName,
                    Movies = a.Movies.Select(m => new
                    {
                        m.MovieId,
                        m.Title,
                        m.ReleaseDate,
                        m.ActorId,
                        m.FilmTypeId
                    }).ToList()
                })
                .FirstOrDefault();
                return Ok(actor);
            }
            catch (Exception ex)
            {
                return BadRequest(new { hiba = ex });
            }
        }

        [HttpGet("feladat12")]
        public ActionResult GetCountOfActors()
        {
            try
            {
                var count = _context.Actors.Count();
                return Ok("Színészek száma: " + count);
            }
            catch (Exception ex)
            {
                return BadRequest(new {hiba = ex});
            }
        }



    }
}
