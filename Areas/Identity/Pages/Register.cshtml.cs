using AgriReachWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AgriReachWeb.Areas.Identity.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AgriReachDbContext _context;

        public RegisterModel(UserManager<User> userManager, SignInManager<User> signInManager, AgriReachDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            [Required] public string FullName { get; set; } = "";
            [Required][EmailAddress] public string Email { get; set; } = "";
            public string? Phone { get; set; }
            [Required] public string Role { get; set; } = "Buyer";
            public string? FarmName { get; set; }
            public string? FarmLocation { get; set; }
            [Required][DataType(DataType.Password)] public string Password { get; set; } = "";
            [DataType(DataType.Password)][Compare("Password")] public string ConfirmPassword { get; set; } = "";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var user = new User
            {
                FullName = Input.FullName.Trim(),
                Email = Input.Email,
                PhoneNumber = Input.Phone,
                Role = Input.Role,
                IsVerified = false,
                DateCreated = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, Input.Password); // PASSWORD IS HASHED HERE

            if (result.Succeeded)
            {
                if (Input.Role == "Farmer")
                {
                    var profile = new Farm
                    {
                        FarmName = Input.FarmName?.Trim() ?? $"{Input.FullName}'s Farm",
                        Address = Input.FarmLocation?.Trim() ?? ""
                    };
                    _context.Farms.Add(profile);
                    await _context.SaveChangesAsync();
                }

                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToPage("/Index");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return Page();
        }
    }
}