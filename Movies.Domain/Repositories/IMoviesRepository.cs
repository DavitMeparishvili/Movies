using Movies.Domain.Entities;
using Movies.Domain.Filters;

namespace Movies.Domain.Repositories;
public interface IMoviesRepository
{
    Task<List<Movie>> GetByExpressionAsync(MoviesFilter filter);

    Task<Movie> GetByIdAsync(string id);
}

