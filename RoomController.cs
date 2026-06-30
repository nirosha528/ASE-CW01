using Microsoft.AspNetCore.Mvc;
using Hotelreservation.Data;
using Hotelreservation.Models;

namespace Hotelreservation.Controllers
{
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LIST
        public IActionResult Index()
        {
            var rooms = _context.Rooms.ToList();
            return View(rooms);
        }

        // CREATE (THIS IS REQUIRED)
        

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Room model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.Rooms.Add(model);
            _context.SaveChanges();

            TempData["Success"] = "Room added successfully!";

            return RedirectToAction("Index");
        }

        // EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room == null) return NotFound();

            return View(room);
        }
        // ✅ CHECK AVAILABLE ROOMS
        public IActionResult CheckAvailability()
        {
            var availableRooms = _context.Rooms
                .Where(r => r.IsAvailable)
                .ToList();

            return View(availableRooms);
        }

        public IActionResult List()
        {
            var rooms = _context.Rooms.ToList();
            return View(rooms);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Room model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.Rooms.Update(model);
            _context.SaveChanges();

            TempData["Success"] = "Room updated successfully!";

            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var room = _context.Rooms.Find(id);

            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();

                TempData["Success"] = "Room deleted successfully!";
            }

            return RedirectToAction("Index");
        }
    }
}