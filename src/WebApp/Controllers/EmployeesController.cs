#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var emps = await _context.Employees.Include(e=>e.Department).Include(e=>e.Account).ToListAsync();
            var model = new List<EmployeeViewModel>();
            foreach (var employee in emps)
            {
                model.Add(GetMappedEmployee(employee));
            }
            return View(model);
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.Include(e => e.Department).Include(e => e.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            var employeeViewModel = GetMappedEmployee(employee);
            if (employeeViewModel == null)
            {
                return NotFound();
            }

            return View(employeeViewModel);
        }
        // GET: Employee/Edit/5 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.Include(e => e.Department).Include(e => e.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            var employeeViewModel = GetMappedEmployee(employee);
            if (employeeViewModel == null)
            {
                return NotFound();
            }
            return View(employeeViewModel);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Phone,Salary,UserName,Email,PhoneNumber,DepartmentName")] EmployeeViewModel employeeViewModel)
        {
            if (id != employeeViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var emp = await _context.Employees.FirstOrDefaultAsync(e=>e.Id==employeeViewModel.Id);
                    emp.Salary = employeeViewModel.Salary;
                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeViewModelExists(employeeViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeViewModel);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Phone,Salary,UserName,Email,PhoneNumber,DepartmentName")] EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeViewModel);
        }

        #region MyRegion

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeViewModel = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeViewModel == null)
            {
                return NotFound();
            }

            return View(employeeViewModel);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeViewModel = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employeeViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private EmployeeViewModel GetMappedEmployee(Employee employee)
        {
            var contakInfo = _context.Contacts.FirstOrDefault(x => x.Id == employee.Id);
            EmployeeViewModel mappedEmployee = new EmployeeViewModel
            {
                Id = employee.Id,
                Name = contakInfo.Name,
                Surname = contakInfo.Surname,
                Phone = contakInfo.Phone,
                Salary = employee.Salary,
                DepartmentName = employee.Department.Name,
                Email = employee.Account.Email,
                PhoneNumber = employee.Account.PhoneNumber,
                UserName = employee.Account.UserName,
            };
            return mappedEmployee;
        }
        #endregion
        private bool EmployeeViewModelExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
