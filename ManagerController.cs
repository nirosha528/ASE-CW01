using Microsoft.AspNetCore.Mvc;

namespace Hotelreservation.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Dashboard()
        {
            var role = HttpContext.Session.GetString("Role");

            if (role != "Manager")
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}
