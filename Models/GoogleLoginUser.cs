using System.ComponentModel.DataAnnotations;

namespace Online_Booking.Models
{
    public class GoogleLoginUser
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

        public static explicit operator ApplicationUsers(GoogleLoginUser model)
        {
            return new ApplicationUsers
            {
                Email = model.Email,
                Name = model.Name,
                Provider = model.Provider,
                ProviderKey = model.ProviderKey
            };
        }
    }
}