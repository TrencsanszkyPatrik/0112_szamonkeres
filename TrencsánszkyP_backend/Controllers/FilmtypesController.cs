using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrencsánszkyP_backend.Models;

namespace TrencsánszkyP_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmtypesController : ControllerBase
    {
        public readonly CinemadbContext _context;
        public FilmtypesController(CinemadbContext context)
        {
            _context = context;
        }


        [HttpGet("feladat11")]
        public ActionResult GetAllTypeWithMovies()
        {
            try
            {
                var filmTypes = _context.FilmTypes
                    .Select(ft => new
                    {
                        ft.TypeId,
                        ft.TypeName,
                        Movies = ft.Movies.Select(m => new
                        {
                            m.MovieId,
                            m.Title,
                            m.ReleaseDate,
                            m.ActorId,
                            m.FilmTypeId
                        }).ToList()
                    })
                    .ToList();
                return Ok(filmTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
