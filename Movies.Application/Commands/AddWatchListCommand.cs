using MediatR;
using Movies.Domain.Entities;

namespace Movies.Application.Commands
{
    public record AddWatchListCommand(string UserId, string MovieId) : IRequest;
}
