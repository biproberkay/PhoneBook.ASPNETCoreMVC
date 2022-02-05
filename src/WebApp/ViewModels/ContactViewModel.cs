using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
        [Phone]
        public string Phone { get; set; }

        [Display(Name ="Whose Contact")]
        public string OwnerFullName { get; set; }

        [Display(Name="Department")]
        public string? DepartmentName { get; set; }
    }
}
