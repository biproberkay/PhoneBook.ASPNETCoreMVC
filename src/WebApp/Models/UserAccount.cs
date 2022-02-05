using Microsoft.AspNetCore.Identity;

namespace WebApp.Models
{
    public class UserAccount : IdentityUser 
    {
        public UserAccount(string userName):base(userName) 
        {

        }
        public string? Name { get; set; }
        public string? Surname { get; set; }

    }
}
