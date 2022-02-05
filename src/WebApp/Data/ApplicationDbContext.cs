using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.ViewModels.Users;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserAccount>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}