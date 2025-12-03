using System;
using System.Collections.Generic;

namespace AgriReachWeb.Models;

public partial class ShoppingList
{
    public int ListId { get; set; }

    public int UserId { get; set; }

    public DateTime? DateCreated { get; set; }

    public virtual ICollection<ShoppingListItem> ShoppingListItems { get; set; } = new List<ShoppingListItem>();

    public virtual User User { get; set; } = null!;
}
