using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public static class SeedData
    {
        public static async void Seed(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<Account>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] users = { "admin", "managerF", "managerHR", "managerIT" };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(new Account($"{user}@phonebook.com") { EmailConfirmed=true}, "Qaz123+");
                    await roleManager.CreateAsync(new IdentityRole($"{user}"));
                    var userCreated = await userManager.FindByNameAsync($"{user}@phonebook.com");
                    await userManager.AddToRoleAsync(userCreated, user);
                } 
                SeedDepartman(context);
                SeedContact(context);
                SeedEmployee(context);
                context.SaveChanges();
            }
        }
        private static List<Department> SeedDepartman(ApplicationDbContext context)
        {
            context.Departments.AddRange(
                new Department[] {
                    new Department { Name = "Administration"},
                    new Department { Name = "Finance"},
                    new Department { Name = "HR"},
                    new Department { Name = "IT-Services" }
                }
            );
            return context.Departments.ToList();
        }

        private static void SeedContact(ApplicationDbContext context)
        {
            var contactList = new List<Contact>
            {
                new Contact {
                    Name = "Kutluk", 
                    Surname = "Ashina", 
                    Phone = "5398220128", 
                },
                new Contact
                {
                    Name = "Kutluk",
                    Surname = "Paralı",
                    Phone = "5398220128",
                },
                new Contact
                {
                    Name = "Kutluk",
                    Surname = "Erkişi",
                    Phone = "5398220128",
                },
                new Contact
                {
                    Name = "Kutluk",
                    Surname = "Bilgili",
                    Phone = "5398220128",
                }

            };
            foreach (var item in contactList)
            {
                context.Contacts.Add(item);
            }
        }

#if true
        private static List<Employee> SeedEmployee(ApplicationDbContext context)
        {
            context.Employees.AddRange(
             new Employee { ContactId = 1, DepartmentId = 1, Salary=5000},
             new Employee { ContactId = 2, DepartmentId = 2, Salary = 5000 },
             new Employee { ContactId = 3, DepartmentId = 3, Salary = 5000 },
             new Employee { ContactId = 4, DepartmentId = 4, Salary = 5000 }
            );
            return context.Employees.ToList();
        }

#endif
    }
}
