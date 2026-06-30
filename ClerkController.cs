using Microsoft.AspNetCore.Mvc;

namespace Hotelreservation.Controllers
{
    public class ClerkController : Controller
    {
        public IActionResult Dashboard()
        {
            var role = HttpContext.Session.GetString("Role");

            if (role != "Clerk")
                return RedirectToAction("Login", "Account");

            return View();
        }
    }
}