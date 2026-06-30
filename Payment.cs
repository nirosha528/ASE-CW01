using System;
using System.ComponentModel.DataAnnotations;

namespace Hotelreservation.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int ReservationId { get; set; }

        public string CustomerName { get; set; } = "";

        public decimal RoomCharge { get; set; }

        public decimal RestaurantCharge { get; set; }

        public decimal RoomServiceCharge { get; set; }

        public decimal LaundryCharge { get; set; }

        public decimal TelephoneCharge { get; set; }

        public decimal ClubFacilityCharge { get; set; }

        public decimal TravelAgencyDiscount { get; set; }

        public decimal TotalAmount { get; set; }

        public string PaymentMethod { get; set; } = "";

        public string Status { get; set; } = "Paid";

        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
