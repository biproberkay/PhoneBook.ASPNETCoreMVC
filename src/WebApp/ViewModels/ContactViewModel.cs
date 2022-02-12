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

#if true
        [Display(Name = "Owner")]
        public string Owner { get; set; }

        [Display(Name = "Department")]
        public string? Department { get; set; } = "NAN"; 

        [Display(Name ="Company")]
        public string Company { get; set;} 

        [Display(Name = "Manager")]
        public string? Manager { get; set; }
#endif

    }
}
