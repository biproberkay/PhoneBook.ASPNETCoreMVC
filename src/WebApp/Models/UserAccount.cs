using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class UserAccount : IdentityUser 
    {
        public UserAccount(string userName):base(userName) 
        {

        }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        [NotMapped]
        public string FullName => $"{Name} {Surname}";
        public ICollection<Contact> ContactList { get; set; }
        public Employee? Employee { get; set; }
        public Department? ManagedDepartment { get; set; }
    }
}
