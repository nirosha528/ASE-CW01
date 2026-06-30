using System.ComponentModel.DataAnnotations;

namespace Hotelreservation.Models
{
    public class ReservationRequest
    {
        [Key]
        public int RequestId { get; set; }

        public string CustomerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public int RoomNo { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public string SpecialRequest { get; set; } = string.Empty;

        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}