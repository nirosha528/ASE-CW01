using System.ComponentModel.DataAnnotations;

namespace Hotelreservation.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        public string RoomNumber { get; set; } = string.Empty;

        [Required]
        public string RoomType { get; set; } = string.Empty;

        [Required]
        public decimal PricePerNight { get; set; }

        [Required]
        public int Capacity { get; set; }

        public bool IsAvailable { get; set; } = true;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}