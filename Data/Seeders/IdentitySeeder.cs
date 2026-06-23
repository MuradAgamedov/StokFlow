using Microsoft.AspNetCore.Identity;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Seeders;

public static class IdentitySeeder
{
    public static async Task SeedAsync(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        var user = await userManager.FindByEmailAsync("admin@stokflow.com");

        if (user == null)
        {
            user = new ApplicationUser
            {
                UserName = "admin@stokflow.com",
                Email = "admin@stokflow.com",
                EmailConfirmed = true
            };

            await userManager.CreateAsync(user, "Admin123*");
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}