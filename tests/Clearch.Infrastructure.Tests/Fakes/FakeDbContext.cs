using Microsoft.EntityFrameworkCore;

namespace Clearch.Infrastructure.IntegrationTests
{
    public sealed class FakeDbContext : DbContext
    {
        public FakeDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Extensions.ModelBuilderExtensions.AddConfigurationsFromAssembly(builder);
        }
    }
}