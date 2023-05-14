using AutoMapper;
using MediatR;
using Movies.Application.Dto;
using Movies.Application.Queries;
using Movies.Domain.Repositories;

namespace Movies.Application.Handlers
{
    public class GetWatchListHandler : IRequestHandler<GetWatchListQuery, IEnumerable<WatchListDto>>
    {
        private readonly IWatchListRepository _watchListRepo;
        private readonly IMoviesRepository _moviesRepo;
        private readonly IMapper _mapper;
        public GetWatchListHandler(IWatchListRepository watchListRepo, IMapper mapper, IMoviesRepository moviesRepo)
        {
            _watchListRepo = watchListRepo;
            _mapper = mapper;
            _moviesRepo = moviesRepo;
        }

        public async Task<IEnumerable<WatchListDto>> Handle(GetWatchListQuery request, CancellationToken cancellationToken)
        {
            var watchLists = await _watchListRepo.GetByUserIdAsync(request.UserId, request.Watched);
            var dtos = _mapper.Map<List<WatchListDto>>(watchLists);

            foreach (var watchListDto in dtos)
            {
                var relatedMovie = await _moviesRepo.GetByIdAsync(watchListDto.MovieId);
                watchListDto.Movie =_mapper.Map<MovieDto>(relatedMovie);
            }

            return dtos;
        }
    }
}
