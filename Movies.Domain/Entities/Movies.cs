namespace Movies.Domain.Entities;

public class Movie
{
    public string Id { get; set; }

    public string Title { get; set; }

    public List<string> GenreList { get; set; }

    public string IMDbRating { get; set; } 

    public DateTime? ReleaseDate { get; set; }

    public List<string> Actors { get; set; }
}
