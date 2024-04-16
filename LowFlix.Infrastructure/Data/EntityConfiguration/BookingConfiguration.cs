
namespace LowFlix.Infrastructure.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using LowFlix.Core.Domain.Entities;
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {

        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(x => x.BookingId);
        }


    }
}
