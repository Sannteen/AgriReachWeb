using System;
using System.Collections.Generic;


namespace AgriReachWeb.Models;

public partial class User
{

    [Key]
    public int UserId { get; set; }

    [Required]
    public string FullName { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? PhoneNumber { get; set; }
    [Required]
    public string Role { get; set; } = null!;

    public bool? IsVerified { get; set; }

    public DateTime? DateCreated { get; set; }

    public virtual ICollection<Message> MessageReceivers { get; set; } = new List<Message>();

    public virtual ICollection<Message> MessageSenders { get; set; } = new List<Message>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();
}
