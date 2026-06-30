using Microsoft.EntityFrameworkCore;
using Hotelreservation.Models;

namespace Hotelreservation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<ReservationRequest> ReservationRequests { get; set; }
    }
}