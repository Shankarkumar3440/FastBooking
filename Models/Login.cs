using System.ComponentModel.DataAnnotations;

namespace Online_Booking.Models
{
    public class Login
    {
        public int id { get; set; }

        [Required]
        public int txtUserId { get; set; }

        [Required]
        public string txtPassword {  get; set; }
    }
}
