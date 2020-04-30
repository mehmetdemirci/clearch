using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Clearch.Infrastructure.Data.Context
{
    public sealed class ReminderDbContext : DbContext
    {
        public ReminderDbContext(DbContextOptions<ReminderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Extensions.ModelBuilderExtensions.AddConfigurationsFromAssembly(builder);
        }
    }
}
