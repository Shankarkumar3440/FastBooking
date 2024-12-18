using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Booking.Models;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.Extensions.Hosting;

namespace Online_Booking.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _context;

        public HomeController(MyDbContext context)
        {
            _context = context;
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
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
         public async Task<IActionResult> Registration(Login user)
        {
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid registration data.");
                return View(user);
            }

            if (ModelState.IsValid)
            {
                if (await _context.Login.AnyAsync(u => u.MobileNo == user.MobileNo))
                {
                    ModelState.AddModelError("MobileNo", "MobileNo is already registered.");
                    return View(user);
                }

                var newUser = new Login
                {
                    MobileNo = user.MobileNo,
                    Password = user.Password, 
                    FirstName= user.FirstName,
                    LastName = user.LastName,
                    Email    = user.Email,
                    Address  = user.Address,
                    City     = user.City,
                    Pincode  = user.Pincode
                };

                _context.Login.Add(newUser);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Registered successfully. Please log in.";
                return RedirectToAction("Login");
            }

            return View(user);
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login user)
        {
            if (string.IsNullOrEmpty(user.MobileNo) || string.IsNullOrEmpty(user.Password))
            {
                ViewBag.Message = "Mobile number and password cannot be empty.";
                return View();
            }

            var myUser = await _context.Login.FirstOrDefaultAsync(x => x.MobileNo == user.MobileNo && x.Password == user.Password);

            if (myUser != null)
            {
                var claims = new List<Claim>();

                if (!string.IsNullOrEmpty(myUser.FirstName))
                {
                    claims.Add(new Claim(ClaimTypes.Name, myUser.FirstName));
                }

                if (!string.IsNullOrEmpty(myUser.MobileNo))
                {
                    claims.Add(new Claim(ClaimTypes.MobilePhone, myUser.MobileNo));
                }


                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("SearchBuses", "Home");
            }
            else
            {

                ViewBag.Message = "Invalid mobile number or password.";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        public IActionResult GoogleLogin()
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse")
            }, "Google");
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault()?.Claims;

            var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (!string.IsNullOrEmpty(email))
            {
                var user = await _context.GoogleLoginUser.FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                {
                    user = new GoogleLoginUser
                    {
                        Email = email,
                        Name = name ?? "Google User",
                        Provider = "Google",
                        ProviderKey = claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value
                    };
                    _context.GoogleLoginUser.Add(user);
                    await _context.SaveChangesAsync();
                }

                var userClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Name)
        };

                var identity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index");
            }

                TempData["Error"] = "Google login failed.";
            return RedirectToAction("Login");
        }

        public IActionResult Admin()
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
