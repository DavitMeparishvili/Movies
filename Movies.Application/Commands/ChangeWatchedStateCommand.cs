using MediatR;

namespace Movies.Application.Commands
{
    public record ChangeWatchedStateCommand(int WatchListId, bool WatchedState) : IRequest;
}
