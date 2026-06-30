using Microsoft.AspNetCore.Mvc;
using Hotelreservation.Data;
using Hotelreservation.Models;

namespace Hotelreservation.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        // LIST
        
        public IActionResult Index()
        {
            var reservations = _context.Reservations.ToList();
            return View(reservations);
        }

     
        // CREATE GET
        
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Rooms = _context.Rooms.ToList();
            return View();
        }

        
        // CREATE POST
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reservation model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Rooms = _context.Rooms.ToList();
                return View(model);
            }

            model.ReservationDate = DateTime.Now;

            _context.Reservations.Add(model);
            _context.SaveChanges();

            TempData["Success"] = "Reservation Saved Successfully!";

            return RedirectToAction("Index");
        }

        // EDIT GET
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var reservation = _context.Reservations.Find(id);

            if (reservation == null)
                return NotFound();

            ViewBag.Rooms = _context.Rooms.ToList();

            return View(reservation);
        }

        // EDIT POST
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Reservation model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Rooms = _context.Rooms.ToList();
                return View(model);
            }

            _context.Reservations.Update(model);
            _context.SaveChanges();

            TempData["Success"] = "Reservation Updated Successfully!";

            return RedirectToAction("Index");
        }

        // DELETE
       
        public IActionResult Delete(int id)
        {
            var reservation = _context.Reservations.Find(id);

            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();

                TempData["Success"] = "Reservation Deleted Successfully!";
            }

            return RedirectToAction("Index");
        }
    }
}