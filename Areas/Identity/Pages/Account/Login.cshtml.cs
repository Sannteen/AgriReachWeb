using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgriReachWeb.Models;
using AgriReachWeb.Data;
using Microsoft.AspNetCore.Identity;  


namespace AgriReachWeb.Pages.Account.UsersLogin  
{
    public class UsersLogin : PageModel  
    {
        private readonly AgriReachDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;  // Add this

        public UsersLogin(AgriReachDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [BindProperty]
        public string Email { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";

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

            // Fix: Check for null PasswordHash before verifying
            if (string.IsNullOrEmpty(user.PasswordHash))
            {
                TempData["Error"] = "Invalid password.";
                return Page();
            }

            // NEW: This single line replaces your old password check
            var hasher = new PasswordHasher<User>();
            var verifyResult = hasher.VerifyHashedPassword(user, user.PasswordHash, Password);

            if (verifyResult == PasswordVerificationResult.Failed)
            {
                TempData["Error"] = "Invalid password.";
                return Page();
            }

            HttpContext.Session.SetString("UserId", user.UserId.ToString());
            HttpContext.Session.SetString("FullName", user.FullName);
            HttpContext.Session.SetString("Role", user.Role);

            if (user.Role == "Farmer")
            {
                return RedirectToAction("Index", "FarmProducts");
            }
            else if (user.Role == "Buyer")
            {
                return RedirectToAction("HomeUser", "Home"); 
            }
            else
            {
                TempData["Error"] = "Unknown user role.";
                return Page();
            }
        }
    }
}