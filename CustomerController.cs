using Hotelreservation.Data;
using Hotelreservation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Hotelreservation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // === DASHBOARD =
        public IActionResult Dashboard()
        {
            var role = HttpContext.Session.GetString("Role");

            if (role != "customer")
                return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult MyBills(string customerName)
        {
            var payment = _context.Payments
                .FirstOrDefault(p => p.CustomerName.Contains(customerName ?? ""));

            return View(payment);
        }
        

        // ======= MY RESERVATIONS =======
        public IActionResult MyReservations()
        {
            var username = HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "Account");

            var data = _context.Reservations
                .Where(r => r.CustomerName == username)
                .ToList();

            return View(data);
        }

        // ========= EDIT (GET) =========
        public IActionResult EditReservation(int id)
        {
            var username = HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "Account");

            var reservation = _context.Reservations
                .FirstOrDefault(r => r.ReservationId == id &&
                                     r.CustomerName == username);

            if (reservation == null)
                return NotFound();

            return View(reservation);
        }

        // ===== EDIT (POST) ======
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditReservation(Reservation model)
        {
            var username = HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "Account");

            var reservation = _context.Reservations
                .FirstOrDefault(r => r.ReservationId == model.ReservationId &&
                                     r.CustomerName == username);

            if (reservation == null)
                return NotFound();

            reservation.CheckInDate = model.CheckInDate;
            reservation.CheckOutDate = model.CheckOutDate;
            reservation.NumberOfGuests = model.NumberOfGuests;
            reservation.SpecialRequest = model.SpecialRequest;

            _context.SaveChanges();

            TempData["Success"] = "Reservation updated successfully!";
            return RedirectToAction("MyReservations");
        }

        // ====== DELETE ===
        public IActionResult DeleteReservation(int id)
        {
            var username = HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "Account");

            var reservation = _context.Reservations
                .FirstOrDefault(r => r.ReservationId == id &&
                                     r.CustomerName == username);

            if (reservation == null)
                return NotFound();

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();

            TempData["Success"] = "Reservation deleted successfully!";
            return RedirectToAction("MyReservations");
        }


        



    }
}