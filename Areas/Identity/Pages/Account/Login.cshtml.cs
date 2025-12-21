using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgriReachWeb.Models;
using AgriReachWeb.Data;
using System.Security.Cryptography;
using System.Text;

namespace AgriReachWeb.Pages.Account.LoginModel
{
    public class UsersLogin : PageModel
    {
        private readonly AgriReachDbContext _context;

        public UsersLogin(AgriReachDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";

        [BindProperty]
        public string Role { get; set; } = "";

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                TempData["Error"] = "Please enter email and password.";
                return Page();
            }

            var user = _context.Users
                .FirstOrDefault(u => u.Email == Email);

            if (user == null)
            {
                TempData["Error"] = "Invalid email";
                return Page();
            }

            else

                // Verify hashed password
                if (user.PasswordHash != HashPassword(Password))
                {
                    TempData["Error"] = "Invalid password.";
                    return Page();
                }

                else

                {

                    // Login successful — create session
                    HttpContext.Session.SetString("UserId", user.UserId.ToString());
                    HttpContext.Session.SetString("FullName", user.FullName);
                    HttpContext.Session.SetString("Role", user.Role);

                if (user.Role == "Farmer")
                {
                    return RedirectToAction("FarmerDashboard", "Home");
                }
                else if (user.Role == "Buyer")
                {
                    return RedirectToAction("HomeUser", "Home");
                }

                else
                {
                        // Handle unknown role
                        TempData["Error"] = "Unknown user role.";
                        return Page();
                    }
                }
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}