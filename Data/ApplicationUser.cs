using Microsoft.AspNetCore.Identity;
using System;

namespace AgriReachWeb.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public int UserId { get; set; }
        public string Role { get; set; }
        public bool? IsVerified { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
