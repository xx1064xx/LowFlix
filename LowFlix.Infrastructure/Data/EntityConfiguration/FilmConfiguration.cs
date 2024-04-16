
namespace LowFlix.Infrastructure.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using LowFlix.Core.Domain.Entities;
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {

        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(x => x.FilmId);
        }

    }
}
