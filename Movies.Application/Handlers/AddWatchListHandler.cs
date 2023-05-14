using AutoMapper;
using MediatR;
using Movies.Application.Commands;
using Movies.Domain.Entities;
using Movies.Domain.Repositories;

namespace Movies.Application.Handlers
{
    public class AddWatchListHandler : IRequestHandler<AddWatchListCommand>
    {
        private readonly IWatchListRepository _repository;
        private readonly IMapper _mapper;

        public AddWatchListHandler(IWatchListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(AddWatchListCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WatchList>(request);
            await _repository.InserAsync(entity);
        }
    }
}
