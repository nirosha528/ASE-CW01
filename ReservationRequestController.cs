using Microsoft.AspNetCore.Mvc;
using Hotelreservation.Data;
using Hotelreservation.Models;
using System.Linq;

namespace Hotelreservation.Controllers
{
    public class ReservationRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReservationRequest/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReservationRequest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReservationRequest model)
        {
            if (ModelState.IsValid)
            {
                _context.ReservationRequests.Add(model);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Reservation request submitted successfully!";

                return RedirectToAction(nameof(Create));
            }

            return View(model);
        }

        // GET: ReservationRequest
        public IActionResult Index()
        {
            var requests = _context.ReservationRequests.ToList();
            return View(requests);
        }

        // GET: ReservationRequest/Delete
        public IActionResult Delete(int id)
        {
            var data = _context.ReservationRequests.Find(id);

            if (data != null)
            {
                _context.ReservationRequests.Remove(data);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Reservation deleted successfully!";
            }

            return RedirectToAction(nameof(Index));
        }
    }

}