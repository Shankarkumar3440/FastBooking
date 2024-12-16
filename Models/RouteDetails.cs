using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Online_Booking.Models
{

    public class RouteDetails
    {
        public int RouteID { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Origin is required.")]
        public string Origin { get; set; } // Keep it as a string for the selected origin.

        [BindProperty]
        [Required(ErrorMessage = "Destination is required.")]
        public string Destination { get; set; } // Keep it as a string for the selected destination.

        [BindProperty]
        [Required(ErrorMessage = "Travel Date is required.")]
        public string? TravelDate { get; set; }

        public List<string> Origins { get; set; } = new List<string>(); // Initialize list.
        public List<string> Destinations { get; set; } = new List<string>(); // Initialize list.

        public int BusID { get; set; }
    }

}



