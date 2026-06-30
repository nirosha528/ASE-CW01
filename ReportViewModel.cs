namespace Hotelreservation.Models
{
    public class ReportViewModel
    {
        public int TotalReservations { get; set; }
        public int TotalUsers { get; set; }
        public int TotalRooms { get; set; }

        public List<string> Months { get; set; } = new();
        public List<int> ReservationCounts { get; set; } = new();
    }
}