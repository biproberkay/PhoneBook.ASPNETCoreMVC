namespace WebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int? Salary { get; set; }

        public int? DepartmentId { get; set; } = 1;
        public Department? Department { get; set; }

        public string UserAccountId { get; set; } 
        public UserAccount UserAccount { get; set; }

    }
}
