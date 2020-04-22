using Clearch.Infrastructure.Data.Context;
using Clearch.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clearch.Infrastructure
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            // Add-Migration 001 -Context DbContextName -OutputDir "Folder/Migrations"

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    MigrateIdentity(services).Wait();
                    MigrateReminder(services).Wait();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger("MigrationManager");
                    logger.LogError(ex, "An error occurred while migrating or seeding the database.");
                }
            }

            return host;
        }

        private async static Task MigrateReminder(IServiceProvider services)
        {
            var context = services.GetRequiredService<ReminderDbContext>();            
            await context.Database.MigrateAsync();
        }

        private async static Task MigrateIdentity(IServiceProvider services)
        {
            var context = services.GetRequiredService<IdentityDbContext>();
            await context.Database.MigrateAsync();

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await IdentityDbContextSeed.SeedAsync(userManager, roleManager);
        }
    }
}
