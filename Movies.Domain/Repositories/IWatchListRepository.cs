using Movies.Domain.Entities;

namespace Movies.Domain.Repositories;

public interface IWatchListRepository
{
    Task<List<WatchList>> GetByUserIdAsync(string userId, bool? watched = null);

    Task InserAsync(WatchList movie);

    Task ChangeWatchedStateAsync(int id, bool watched);
}
