using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowFlix.Infrastructure.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using LowFlix.Core.Domain.Entities;
    public class FilmCopyConfiguration : IEntityTypeConfiguration<FilmCopy>
    {

        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<FilmCopy> builder)
        {
            builder.HasKey(x => x.FilmCopyId);
            builder.HasKey(x => x.FilmId);
            builder.Property(x => x.isAvailable).IsRequired();
        }


    }
}
