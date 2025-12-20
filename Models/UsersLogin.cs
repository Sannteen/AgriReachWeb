using System.ComponentModel.DataAnnotations;

namespace AgriReachWeb.Models
{
    public class UsersLogin
    {
        

        [Key]
        public int UserId { get; set; }

        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = null!;

        [Required]
        public string? PasswordHash { get; set; } = null!;

        public string Role { get; set; } = null!;



    }
}
