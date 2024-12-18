using System.ComponentModel.DataAnnotations;

namespace Online_Booking.Models
{
    public class Login
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [Phone(ErrorMessage = "Invalid mobile number format")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Pincode must be 6 digits.")]
        public string Pincode { get; set; }
    }
}

