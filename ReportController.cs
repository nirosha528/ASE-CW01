using Hotelreservation.Data;
using Hotelreservation.Models;
   
using Microsoft.AspNetCore.Mvc;

namespace Hotelreservation.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new ReportViewModel
            {
                TotalReservations = _context.Reservations.Count(),
                TotalUsers = _context.Users.Count(),
                TotalRooms = _context.Rooms.Count(),

                Months = new List<string>
                {
                    "Jan", "Feb", "Mar", "Apr", "May", "Jun"
                },

                ReservationCounts = new List<int>
                {
                    _context.Reservations.Count(r => r.ReservationDate.Month == 1),
                    _context.Reservations.Count(r => r.ReservationDate.Month == 2),
                    _context.Reservations.Count(r => r.ReservationDate.Month == 3),
                    _context.Reservations.Count(r => r.ReservationDate.Month == 4),
                    _context.Reservations.Count(r => r.ReservationDate.Month == 5),
                    _context.Reservations.Count(r => r.ReservationDate.Month == 6)
                }
            };

            return View(model);
        }
    
    public IActionResult Revenue()
        {
            var totalRevenue = _context.Payments
                .Sum(p => p.TotalAmount);

            ViewBag.TotalRevenue = totalRevenue;

            var payments = _context.Payments.ToList();

            return View(payments);
        }
    }}


