using System.ComponentModel.DataAnnotations;

namespace Hotelreservation.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Check-in date is required")]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Check-out date is required")]
        public DateTime CheckOutDate { get; set; }

        [Required(ErrorMessage = "Number of guests is required")]
        public int NumberOfGuests { get; set; }

        [Required(ErrorMessage = "Room is required")]
        public int RoomId { get; set; }

        public string SpecialRequest { get; set; } = string.Empty;

        public DateTime ReservationDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pending";
    }
}