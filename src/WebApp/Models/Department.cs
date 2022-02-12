namespace WebApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Contact> Contacts { get; set; } 
        public ICollection<Employee> Employees { get; set; }

        public string? ManagerId { get; set; }
        public UserAccount? Manager { get; set; }
    }
}
