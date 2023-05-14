using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using Movies.Domain.Exceptions;
using Movies.Domain.Repositories;
using Movies.Infrastructure.DbContext;

namespace Movies.Infrastructure.Repositories
{
    public class WatchListRepository : IWatchListRepository
    {
        private readonly MoviesDbContext _dbContext;

        public WatchListRepository(MoviesDbContext dbContext) => _dbContext = dbContext;

        public async Task<List<WatchList>> GetByUserIdAsync(string userId, bool? watched = null)
        {
            var query = _dbContext.WatchLists.Where(x => x.UserId == userId);

            if (watched is not null)
            {
                query = query.Where(x => x.Watched == watched);
            }

            return await query.ToListAsync();
        }

        public async Task InserAsync(WatchList movie)
        {
            _dbContext.WatchLists.Add(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ChangeWatchedStateAsync(int id, bool watched)
        {
            var entityToModify = await _dbContext.WatchLists.FirstOrDefaultAsync(x => x.Id == id);
            
            if(entityToModify == null)
            {
                throw new BadRequestException("Movies Does not exists");
            }

            entityToModify.Watched = watched;

            await _dbContext.SaveChangesAsync();
        }
    }
}
