using AutoMapper;
using MediatR;
using Movies.Application.Dto;
using Movies.Application.Queries;
using Movies.Domain.Filters;
using Movies.Domain.Repositories;

namespace Movies.Application.Handlers;

public class GetMoviesHandler : IRequestHandler<GetMoviesQuery, IEnumerable<MovieDto>>
{
    private readonly IMoviesRepository _repo;
    private readonly IMapper _mapper;
    public GetMoviesHandler(IMoviesRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var filter = _mapper.Map<MoviesFilter>(request);
        var movies = await _repo.GetByExpressionAsync(filter);
        return _mapper.Map<List<MovieDto>>(movies);
    }
}

