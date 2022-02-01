using Microsoft.AspNetCore.Identity;

namespace WebApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerId { get; set; }
        public IdentityUser Manager { get; set; }
        public List<Employee> Employees { get; set; }
    }
}