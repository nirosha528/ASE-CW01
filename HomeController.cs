using Hotelreservation.Data;
using Hotelreservation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotelreservation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult About()
        {
            return View();
        }

        // ? CHECK AVAILABLE ROOMS
        public IActionResult CheckAvailability()
        {
            var availableRooms = _context.Rooms
                .Where(r => r.IsAvailable)
                .ToList();

            return View(availableRooms);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}