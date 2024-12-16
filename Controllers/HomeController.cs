using Microsoft.AspNetCore.Mvc;
using Online_Booking.Models;
using System.Diagnostics;

namespace Online_Booking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult SearchBuses()
        {
            var model = new RouteDetails();

            // Debugging log to check model state
            if (model == null || model.Origins == null || model.Destination == null)
            {
                Console.WriteLine("Model or its properties are null!");
            }

            return View(model);
        }



        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
       
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
