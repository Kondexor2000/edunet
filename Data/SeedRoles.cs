using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Worknet.Data
{
    public class SeedRoles
    {
        private static readonly SemaphoreSlim _semaphore = new(1, 1);

        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            await _semaphore.WaitAsync();
            try
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string[] roleNames = { "Administrator", "Autor" };

                foreach (var roleName in roleNames)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }

                var user = await userManager.FindByEmailAsync("admin@example.com");
                if (user != null)
                {
                    await userManager.AddToRoleAsync(user, "Administrator");
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}