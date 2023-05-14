using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;

namespace Movies.Persistence.DbContext
{
    public class MoviesDbContext : Microsoft.EntityFrameworkCore.DbContext, IMoviesDbContext
    {

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<WatchList> WatchLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-5OOCU00\\SQLEXPRESS01;Database=ExchangeRates;Trusted_Connection=True;");
        }
    }
}
