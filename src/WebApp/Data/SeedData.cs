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
                var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] users = { "admin", "manager", "manager01", "manager02" };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(new IdentityUser($"{user}@phonebook.com") { EmailConfirmed=true}, "Qaz123+");
                    await roleManager.CreateAsync(new IdentityRole($"{user}"));
                    var userCreated = await userManager.FindByNameAsync($"{user}@phonebook.com");
                    await userManager.AddToRoleAsync(userCreated, user);
                } 
            }
                SeedDepartman(context);
                SeedContact(context);
            context.SaveChanges();
        }

        private static void SeedContact(ApplicationDbContext context)
        {
            var users = context.Users.ToList();
            var employees = SeedEmployee(context);
            var contactList = new List<Contact>
            {
                new Contact {
                    Name = "Kutluk", Surname = "Ashina", Phone = "5398220128", OwnerId = users[0].Id
                },
                new Contact
                {
                    Name = "Kutluk",
                    Surname = "Paralı",
                    Phone = "5398220128",
                    OwnerId = users[0].Id
                },
                new Contact
                {
                    Name = "Kutluk",
                    Surname = "Erkişi",
                    Phone = "5398220128",
                    OwnerId = users[0].Id
                },
                new Contact
                {
                    Name = "Kutluk",
                    Surname = "Bilgili",
                    Phone = "5398220128",
                    OwnerId = users[0].Id
                }

            };
            foreach (var item in contactList)
            {
                context.Contacts.Add(item);
            }
        }

        private static List<Employee> SeedEmployee(ApplicationDbContext context)
        {
            context.Employees.AddRange(
             new Employee { ContactId = 1, DepartmentId = 1 },
             new Employee { ContactId = 2, DepartmentId = 2},
             new Employee { ContactId = 3, DepartmentId = 3},
             new Employee { ContactId = 4, DepartmentId = 4}
            );
            return context.Employees.ToList();
        }

        private static List<Department> SeedDepartman(ApplicationDbContext context)
        {
            var users = context.Users.ToList();
            context.Departments.AddRange(
                new Department[] {
                    new Department { Name = "Administration", ManagerId = users[0].Id},
                    new Department { Name = "Finance", ManagerId = users[1].Id},
                    new Department { Name = "HR", ManagerId = users[2].Id },
                    new Department { Name = "IT-Services", ManagerId = users[3].Id }
                }
            );
            return context.Departments.ToList();
        }
    }
}
