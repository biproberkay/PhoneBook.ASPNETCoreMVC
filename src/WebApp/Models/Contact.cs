using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Contact
    {
#if false
        public string fullName;
        public Contact()
        {
            fullName = Name + " " + Surname;
        } 
#endif
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public int? OwnerId { get; set; }
        public Employee? Owner { get; set; }

    }
}
