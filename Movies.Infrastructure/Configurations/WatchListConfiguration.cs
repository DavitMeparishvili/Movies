using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities;

namespace Persistence.Configurations
{
    internal sealed class WatchListConfiguration : IEntityTypeConfiguration<WatchList>
    {
        public void Configure(EntityTypeBuilder<WatchList> builder)
        {
            builder.ToTable(nameof(WatchList));

            builder.HasKey(watchList => watchList.Id);

            builder.Property(watchList => watchList.Id).ValueGeneratedOnAdd();

            builder.Property(watchList => watchList.MovieId).IsRequired();

            builder.Property(watchList => watchList.UserId).IsRequired();
        }
    }
}
