using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;

namespace Movies.Persistence.DbContext
{
    public interface IMoviesDbContext
    {
        DbSet<User> Users { get; set; }

        DbSet<WatchList> WatchLists { get; set; }
    }
}
