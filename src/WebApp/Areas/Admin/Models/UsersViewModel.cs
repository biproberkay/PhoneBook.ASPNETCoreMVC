using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Areas.Admin.Models
{
    public class UsersViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        [Email]
        public string Email { get; set; }

        [Display(Name ="Full Name")]
        public string FullName { get; set; }

        [Display(Name ="email doğrulaması")]
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public List<string> Roles { get; set; }
        public string? Role { get; set; }
    }
}
