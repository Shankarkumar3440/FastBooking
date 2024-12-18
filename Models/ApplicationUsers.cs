using System.ComponentModel.DataAnnotations;

namespace Online_Booking.Models
{
    public class ApplicationUsers
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        public string Provider { get; set; }
        [Required]
        public string ProviderKey { get; set; }
    }
}
