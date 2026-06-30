using System.ComponentModel.DataAnnotations;

namespace Hotelreservation.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // manager/clerk/customer/travelagency
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}