using Microsoft.AspNetCore.Identity;

namespace WebApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }
        //public Employee Manager { get; set; }
        public List<Employee> Employees { get; set; }
    }
}