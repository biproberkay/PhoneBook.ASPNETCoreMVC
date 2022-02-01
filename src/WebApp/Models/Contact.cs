using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Contact
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string OwnerId { get; set; }
        public IdentityUser Owner { get; set; }

        public Employee? Employee { get; set; }

    }
}
