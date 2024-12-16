﻿using System.ComponentModel.DataAnnotations;

namespace Online_Booking.Models
{
    public class Registration
    {
            public int id {  get; set; }
 
            [Required]
            [StringLength(50)]
            public string FirstName { get; set; }

            [Required]
            [StringLength(50)]
            public string LastName { get; set; }

            [Required]
            [Phone]
            public string MobileNo { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

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


