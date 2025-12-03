using System;
using System.Collections.Generic;

namespace AgriReachWeb.Models;

public partial class ShoppingListItem
{
    public int ItemId { get; set; }

    public int ListId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public virtual ShoppingList List { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
