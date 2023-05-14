using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using Movies.Domain.Repositories;

namespace Movies.Infrastructure.DbContext
{
    public class MoviesDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MoviesDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<WatchList> WatchLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MoviesDbContext).Assembly);

            modelBuilder.Entity<WatchList>()
                .Property(w => w.UserId)
                .IsRequired()
                .HasMaxLength(250);

            modelBuilder.Entity<WatchList>()
                .Property(w => w.MovieId)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
