using System;
using System.Collections.Generic;

namespace TrencsánszkyP_backend.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    public int ActorId { get; set; }

    public int FilmTypeId { get; set; }

    public virtual Actor Actor { get; set; } = null!;

    public virtual FilmType FilmType { get; set; } = null!;
}
