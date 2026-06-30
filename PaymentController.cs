using Hotelreservation.Data;
using Hotelreservation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Hotelreservation.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // SHOW CREATE + LIST
        public IActionResult Create()
        {
            var payments = _context.Payments.ToList();

            ViewBag.Payments = payments;

            return View();
        }

        // SAVE PAYMENT
        [HttpPost]
        public IActionResult Create(Payment payment)
        {
            payment.TotalAmount =
                payment.RoomCharge +
                payment.RestaurantCharge +
                payment.RoomServiceCharge +
                payment.LaundryCharge +
                payment.TelephoneCharge +
                payment.ClubFacilityCharge -
                payment.TravelAgencyDiscount;

            _context.Payments.Add(payment);
            _context.SaveChanges();

            TempData["Success"] = "Payment saved successfully!";

            return RedirectToAction("Create");
        }
    }
}