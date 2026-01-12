namespace TrencsánszkyP_backend.Models
{
    public class AddNewDto
    {

        public string Title { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        public int ActorId { get; set; }

        public int FilmTypeId { get; set; }
    }
}
