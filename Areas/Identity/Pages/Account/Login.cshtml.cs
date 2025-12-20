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
                .FirstOrDefault(u => u.Email == Email );

            var pword = _context.Users
                .FirstOrDefault(u => u.PasswordHash == Password);


            var user_role = _context.Users
                .FirstOrDefault(u => u.Role == Role );

            if (user == null)
            {
                TempData["Error"] = "Invalid email or password.";
                return Page();
            }

            // Verify hashed password
            if (user.PasswordHash != HashPassword(Password))
            {
                TempData["Error"] = "Invalid email or password.";
                return Page();
            }

            // Login successful — create session
            HttpContext.Session.SetString("UserId", user.UserId.ToString());
            HttpContext.Session.SetString("FullName", user.FullName);
            HttpContext.Session.SetString("Role", user.Role);

            if (user.Role == "Famer")
            {

                return RedirectToPage("/view/Home/FarmerDashboard"); // or dashboard
            }

            else
            {

                return RedirectToPage("/view/User/Details"); // or dashboard

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