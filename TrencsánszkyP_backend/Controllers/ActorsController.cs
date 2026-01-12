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

            if (actor == null)
            {
                return NotFound(new {
                    title = "Not found",
                    status = 404
                });
            }
            return Ok(actor);
        }



    }
}
