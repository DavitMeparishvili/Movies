namespace Movies.Domain.Filters
{
    public class MoviesFilter
    {
        public string? Title { get; set; }

        public int? LanguageId { get; set; }

        public DateTime? ReleaseDateTo { get; set; }

        public DateTime?  ReleaseDateFrom { get; set; }

        public int? Genre { get; set; }

        public decimal? UserRatingFrom { get; set; }

        public decimal? UserRatingTo { get; set; }

    }
}
