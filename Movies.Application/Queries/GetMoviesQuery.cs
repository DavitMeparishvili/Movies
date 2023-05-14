using MediatR;
using Movies.Application.Dto;
using Movies.Application.Enums;

namespace Movies.Application.Queries
{
    public record GetMoviesQuery(
        string? Title,
        Languages? LanguageId, 
        DateTime? ReleaseDateTo, 
        DateTime? ReleaseDateFrom,
        Genres? Genre, 
        decimal? UserRatingFrom,
        decimal? UserRatingTo) : IRequest<IEnumerable<MovieDto>>;
}
