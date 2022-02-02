using Microsoft.AspNetCore.Identity;

namespace WebApp.Models
{
    public class Account : IdentityUser
    {
        public Account(string userName):base(userName)
        {

        }
        public int? EmployeeId { get; set; }

    }
}
