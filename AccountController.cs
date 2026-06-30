using Microsoft.AspNetCore.Mvc;
using Hotelreservation.Data;
using Hotelreservation.Models;

namespace Hotelreservation.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Login()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // SESSION
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role", user.Role);

            var role = user.Role.Trim().ToLower();

            // == ROLE ROUTING ====

            switch (role)

            { 
                
                case "manager":
                    return RedirectToAction("Dashboard", "Manager");

                case "clerk":
                    return RedirectToAction("Dashboard", "Clerk");

                case "travelagency":
                    return RedirectToAction("Dashboard", "TravelAgency");

                case "customer":
                    return RedirectToAction("Dashboard", "Customer");

                default:
                   return RedirectToAction("Dashboard", "TravelAgency");
            }
        }
    }
}

