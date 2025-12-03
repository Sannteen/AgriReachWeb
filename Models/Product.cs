using System;
using System.Collections.Generic;

namespace AgriReachWeb.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public string Category { get; set; } = null!;

    public virtual ICollection<Produce> Produces { get; set; } = new List<Produce>();

    public virtual ICollection<ShoppingListItem> ShoppingListItems { get; set; } = new List<ShoppingListItem>();
}
