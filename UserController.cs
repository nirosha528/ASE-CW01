using Microsoft.AspNetCore.Mvc;
using Hotelreservation.Data;
using Hotelreservation.Models;

namespace Hotelreservation.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LIST USERS
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        // CREATE - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.Users.Add(model);
            _context.SaveChanges();

            TempData["Success"] = "User created successfully!";
            return RedirectToAction("Index");
        }

        // EDIT - GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            return View(user);
        }

        // EDIT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.Users.Update(model);
            _context.SaveChanges();

            TempData["Success"] = "User updated successfully!";
            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();

                TempData["Success"] = "User deleted successfully!";
            }

            return RedirectToAction("Index");
        }
    }
}
