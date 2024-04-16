
namespace LowFlix.Infrastructure.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using LowFlix.Core.Domain.Entities;
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.CustomerId);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(80);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(80);
        }

    }
}
