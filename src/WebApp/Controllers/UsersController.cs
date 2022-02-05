#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.ViewModels.Users;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            var model = new List<UserViewModel>();
            foreach (var user in users)
            {
                model.Add(new UserViewModel
                {
                    UserName = user.UserName,
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    PhoneNumber = user.PhoneNumber,
                    Surname = user.Surname,
                });
            }
            return View(model);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            var userViewModel = new UserViewModel
            {
                UserName = user.UserName,
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Surname = user.Surname,
            };

            return View(userViewModel);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Surname,PhoneNumber,UserName")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            var userViewModel = new UserViewModel
            {
                UserName = user.UserName,
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Surname = user.Surname,
            };

            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Email,Surname,PhoneNumber,UserName")] UserViewModel userViewModel)
        {
            if (id != userViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _context.Users
                        .FirstOrDefaultAsync(m => m.Id == id);
                    user.Name = userViewModel.Name;
                    user.Surname = userViewModel.Surname;
                    user.UserName = userViewModel.UserName;
                    user.Email = userViewModel.Email;
                    user.PhoneNumber = userViewModel.PhoneNumber;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserViewModelExists(userViewModel.Id))
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
            return View(userViewModel);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userViewModel = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userViewModel == null)
            {
                return NotFound();
            }

            return View(userViewModel);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userViewModel = await _context.Users.FindAsync(id);
            _context.Users.Remove(userViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserViewModelExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
