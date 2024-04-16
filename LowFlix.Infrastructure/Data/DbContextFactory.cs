
namespace LowFlix.Infrastructure.Data
{
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using LowFlix.Core.Domain;
    using LowFlix.Core.Interfaces.Data;
    public class DbContextFactory : IDbContextFactory
    {

        private static readonly Assembly ConfigurationsAssembly = typeof(DbContextFactory).Assembly;
        private readonly DbContextOptionsBuilder<LowFlixContext> optionsBuilder;

        public DbContextFactory(IConfiguration configuration)
        {
            this.optionsBuilder = new DbContextOptionsBuilder<LowFlixContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            this.optionsBuilder.UseSqlServer(connectionString);
        }

        /// <inheritdoc/>
        public LowFlixContext CreateContext()
        {
            return new LowFlixContext(this.optionsBuilder.Options, ConfigurationsAssembly);
        }

        /// <inheritdoc/>
        public LowFlixContext CreateReadOnlyContext()
        {
            var context = new LowFlixContext(this.optionsBuilder.Options, ConfigurationsAssembly);
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return context;
        }

    }
}
