using AgriReachWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;

namespace AgriReachWeb.Controllers
{
    public class Login : Controller
    {
        private readonly AgriReachDbContext _context;

        public Login()
        {
            _context = new AgriReachDbContext();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Username and password are required.";
                return View();
            }

            // Query the database for the user
            var user = _context.Users
                .FirstOrDefault(u => u.Email == email && u.PasswordHash == password);

            if (user != null)
            {
                // Authentication success
                // FormsAuthentication.SetAuthCookie(user.Username, false); // Uncomment and implement as needed
                return RedirectToAction("Index", "FarmProducts");
            }
            else
            {
                // Authentication failed
                ViewBag.Error = "Invalid username or password.";
                return View();
            }
        }

        // GET: Logout
        public ActionResult Logout()
        {
            // FormsAuthentication.SignOut(); // Uncomment and implement as needed
            return RedirectToAction("Index", "Login");
        }
    }
}
