using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowFlix.Core.Domain
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using LowFlix.Core.Domain.Entities;
    public class LowFlixContext : DbContext
    {

        private readonly Assembly entityConfigurationsAssembly;

        public LowFlixContext(DbContextOptions<LowFlixContext> options, Assembly entityConfigurationsAssembly)
            : base(options)
        {
            this.entityConfigurationsAssembly = entityConfigurationsAssembly;
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<FilmCopy> FilmCopies { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            // Automatically Add all entity configurations
            modelBuilder.ApplyConfigurationsFromAssembly(this.entityConfigurationsAssembly, type => type.Namespace?.EndsWith(".EntityConfigurations", StringComparison.Ordinal) == true);

            // Remove OnDeleteCascade from all Foreign Keys
            var foreignKeys = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in foreignKeys)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
}
