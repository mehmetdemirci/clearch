using Clearch.Infrastructure.Data.Context;
using Clearch.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clearch.Infrastructure
{
    public static class DependencyExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReminderDbContext>(options =>
               options.UseSqlite(
                   configuration.GetConnectionString("ReminderConnection"),
                   b => b.MigrationsAssembly(typeof(ReminderDbContext).Assembly.FullName)));

            services.AddDbContext<IdentityDbContext>(options =>
               options.UseSqlite(
                   configuration.GetConnectionString("IdentityConnection"),
                   b => b.MigrationsAssembly(typeof(IdentityDbContext).Assembly.FullName)));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, IdentityDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}
