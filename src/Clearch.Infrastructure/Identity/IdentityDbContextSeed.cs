using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Clearch.Infrastructure.Identity
{
    public class IdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(IdentityConstants.Roles.ADMINISTRATORS));

            string userName = "demouser@clearch.com";
            var defaultUser = new ApplicationUser { UserName = userName, Email = userName };
            await userManager.CreateAsync(defaultUser, IdentityConstants.DEFAULT_PASSWORD);

            var user = await userManager.FindByEmailAsync(userName);
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            await userManager.ConfirmEmailAsync(user, token);

            string adminUserName = "admin@clearch.com";
            var adminDefaultUser = new ApplicationUser { UserName = adminUserName, Email = adminUserName };
            await userManager.CreateAsync(adminDefaultUser, IdentityConstants.DEFAULT_PASSWORD);

            adminDefaultUser = await userManager.FindByNameAsync(adminUserName);
            await userManager.AddToRoleAsync(adminDefaultUser, IdentityConstants.Roles.ADMINISTRATORS);

            var adminUser = await userManager.FindByEmailAsync(adminUserName);
            var adminToken = await userManager.GenerateEmailConfirmationTokenAsync(adminUser);
            await userManager.ConfirmEmailAsync(adminUser, adminToken);
        }
    }
}
