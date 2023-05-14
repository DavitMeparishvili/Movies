using MediatR;
using Movies.Application.Commands;
using Movies.Domain.Repositories;

namespace Movies.Application.Handlers
{
    public class ChangeWatchedStatehandler : IRequestHandler<ChangeWatchedStateCommand>
    {
        private readonly IWatchListRepository _repo;

        public ChangeWatchedStatehandler(IWatchListRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(ChangeWatchedStateCommand request, CancellationToken cancellationToken)
        {
            await _repo.ChangeWatchedStateAsync(request.WatchListId, request.WatchedState);
        }
    }
}
