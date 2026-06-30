using Microsoft.AspNetCore.Mvc;

namespace Hotelreservation.Controllers
{
    public class TravelAgencyController : Controller
    {
        public IActionResult Dashboard()
        {
            var role = HttpContext.Session.GetString("Role");

            if (role != "travelagency")
                return RedirectToAction("Login", "Account");

            return View();
        }
    }
}