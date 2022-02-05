namespace WebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        //public Contact Contact { get; set; }
        public int? Salary { get; set; }
        public int? AccountId { get; set; }
        public Account? Account { get; set; }
        public int DepartmentId { get; set; } = 1;
        public Department Department { get; set; }
        public List<Contact> ContactList { get; set; }

    }
}
