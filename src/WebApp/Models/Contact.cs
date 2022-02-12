using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public string OwnerId { get; set; }
        public UserAccount Owner { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; } 
    }
}
