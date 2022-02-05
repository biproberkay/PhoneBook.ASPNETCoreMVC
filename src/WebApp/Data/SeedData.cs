using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public static class SeedData
    {
        public static async void Seed(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<UserAccount>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] users = { "admin","employee","manager","HR","IT","Administration" };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(new UserAccount($"{user}@phonebook.com") { EmailConfirmed=true}, "Qaz123+");
                    await roleManager.CreateAsync(new IdentityRole($"{user}"));
                    var userCreated = await userManager.FindByNameAsync($"{user}@phonebook.com");
                    await userManager.AddToRoleAsync(userCreated, user);
                } 
                context.SaveChanges();
            }
        }
    }
}
