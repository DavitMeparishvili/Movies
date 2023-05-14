namespace Movies.Application.Dto
{
    public class WatchListDto
    {
        public int Id { get; set; }

        public string UserId { get; set; } = default!;

        public string MovieId { get; set; } = default!;

        public bool Watched { get; set; }

        public MovieDto? Movie { get; set; }
    }
}
