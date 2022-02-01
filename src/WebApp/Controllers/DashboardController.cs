using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DashboardController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var contacts = _context.Contacts
                .Include(c=>c!.Employee)
                    .ThenInclude(e=>e!.Department).ToList();
            var authUser = _userManager.GetUserAsync(User).Result;
            var authContact = contacts.FirstOrDefault(c => c.OwnerId == authUser.Id);
            if (authContact==null)
            {
                return RedirectToAction(nameof(CreateYourOwnContactRecord));
            }
            
            return View(contacts);
        }
        public IActionResult Employees()
        {
            var employees = _context.Employees
                .Include(d => d.Contact)
                .Include(e=>e.Department)
                .ToList();

            return View(employees);
        }
        public IActionResult CreateYourOwnContactRecord()
        {
            ViewData["OwnerId"] = _userManager.GetUserId(User);
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateYourOwnContactRecord([Bind("Id,Name,Surname,Phone,OwnerId")] Contact contact)
        {
            _context.Add(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
