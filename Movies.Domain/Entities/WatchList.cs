namespace Movies.Domain.Entities;
public class WatchList
{
    public int Id { get; set; }

    public string UserId { get; set; } = default!;

    public string  MovieId { get; set; } = default!;

    public bool Watched { get; set; }
}
