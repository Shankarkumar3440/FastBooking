using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Booking.Models
{ 

        public class RouteDetails
        {
        public int id { get; set; }
        [Required]
        public string Origin { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime TravelDate { get; set; }

        public List<BusRoute> AvailableBuses { get; set; } = new List<BusRoute>();
        public bool IsSearchCompleted { get; set; } = false;
    }
    }



