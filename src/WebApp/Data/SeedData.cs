using Microsoft.AspNetCore.Identity;
using WebApp.Models;

namespace WebApp.Data
{
    public static class SeedData
    {
        public static async void Seed(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<UserAccount>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] users = { "admin","manager","employee","user","finance","HR","IT" };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(new UserAccount($"{user}@phonebook.com") { EmailConfirmed = true }, "Qaz123+");
                    await roleManager.CreateAsync(new IdentityRole($"{user}"));
                    var userCreated = await userManager.FindByNameAsync($"{user}@phonebook.com");
                    await userManager.AddToRoleAsync(userCreated, user);
                }
            }
            if (!context.Departments.Any())
            {
                SeedContact(context);
                SeedCompany(context);
                SeedDepartman(context);
                SeedEmployee(context);
                context.SaveChanges();
            }
        }
        private static List<Company> SeedCompany(ApplicationDbContext context)
        {
            var companies = new List<Company>{
                new Company{ Name = "Evil Company"}
            };
            context.AddRange(companies);
            return companies;
        }
        private static List<Department> SeedDepartman(ApplicationDbContext context)
        {
            var list = new List<Department> {
                new Department { Name = "Administration", CompanyId = 1 },
                new Department { Name = "Finance", CompanyId = 1 },
                new Department { Name = "HR", CompanyId = 1 },
                new Department { Name = "IT-Services", CompanyId = 1 }
            };
            context.Departments.AddRange(list);
            return context.Departments.ToList();
        }
        private static void SeedContact(ApplicationDbContext context)
        {
            var users = context.Users.ToList();
            var contactList = new List<Contact>
            {
                new Contact {
                    Name = "Kutluk", 
                    Surname = "Başkan", 
                    Phone = "5398220128",
                    OwnerId = users[0].Id
                },
                new Contact
                {
                    Name = "Bumin",
                    Surname = "Zengin",
                    Phone = "5398220128",
                    OwnerId = users[0].Id
                },
                new Contact
                {
                    Name = "Taspar",
                    Surname = "Seçen",
                    Phone = "5398220128",
                    OwnerId = users[0].Id
                },
                new Contact
                {
                    Name = "Kültigin",
                    Surname = "Bilen",
                    Phone = "5398220128",
                    OwnerId = users[0].Id
                },
                new Contact
                {
                    Name = "Taspar",
                    Surname = "Böke",
                    Phone = "5398220128",
                    OwnerId = users[0].Id
                }

            };
            context.Contacts.AddRange(contactList);
        }
        private static List<Employee> SeedEmployee(ApplicationDbContext context)
        {
            var users = context.Users.ToList();
            var list = new List<Employee>
            {
                new Employee { UserAccountId = users[0].Id, DepartmentId = 1, Salary = 5000 },
                new Employee { UserAccountId = users[1].Id, DepartmentId = 2, Salary = 5000 },
                new Employee { UserAccountId = users[2].Id, DepartmentId = 3, Salary = 5000 },
                new Employee { UserAccountId = users[3].Id, DepartmentId = 4, Salary = 5000 },
                new Employee { UserAccountId = users[4].Id, DepartmentId = 3, Salary = 5000 }
            };
            context.Employees.AddRange(list);
            return context.Employees.ToList();
        }



    }
}
