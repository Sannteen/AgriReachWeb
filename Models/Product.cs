using System;
using System.Collections.Generic;

namespace AgriReachWeb.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public int ProductCategoryId { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<FarmProduct> FarmProducts { get; set; } = new List<FarmProduct>();

    public virtual ICollection<Product> InverseProductCategory { get; set; } = new List<Product>();

    public virtual Product ProductCategory { get; set; } = null!;

    public virtual ProductCategory ProductNavigation { get; set; } = null!;

    public virtual ICollection<ShoppingListItem> ShoppingListItems { get; set; } = new List<ShoppingListItem>();
}
