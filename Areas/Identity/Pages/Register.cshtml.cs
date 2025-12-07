using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgriReachWeb.Models;
using AgriReachWeb.Data;
using System.Security.Cryptography;
using System.Text;

namespace AgriReachWeb.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly AgriReachDbContext _context;

        public RegisterModel(AgriReachDbContext context)
        {
            _context = context;
        }   

        [BindProperty]
        public User User { get; set; } = new();

        [BindProperty]
        public Farm Farm { get; set; } = new();

        [BindProperty]
        public string Password { get; set; } = "";

        [BindProperty]
        public string ConfirmPassword { get; set; } = "";

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Password != ConfirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return Page();
            }

            // Hash password
            User.PasswordHash = HashPassword(Password);
            User.IsVerified = false;
            User.DateCreated = DateTime.Now;

            _context.Users.Add(User);
            await _context.SaveChangesAsync(); //  Gets UserId

            // Only create Farm if user is Farmer
            if (User.Role == "Farmer")
            {
                var farm = new Farm
                {
                    UserId = User.UserId,
                    FarmName = "My Farm",           // default
                    Address = "Jamaica",
                    Parish = "Not specified",       // default
                    Produces = "Various crops",     // default
                    Product = "Fresh produce",      // default
                    AreaId = null,                  // nullable
                    Area = null,
                    DateRegistered = DateTime.Now
                };

                _context.Farms.Add(farm);
                await _context.SaveChangesAsync();
            }

            TempData["Success"] = "Account created successfully!";
            return RedirectToPage("/Account/Login");
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}