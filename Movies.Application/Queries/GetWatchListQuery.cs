using MediatR;
using Movies.Application.Dto;
using Movies.Domain.Entities;

namespace Movies.Application.Queries
{
    public record GetWatchListQuery(string UserId, bool? Watched = null) : IRequest<IEnumerable<WatchListDto>>;
}
