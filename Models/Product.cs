using System;
using System.Collections.Generic;

namespace AgriReachWeb.Models;

public partial class Product
{

    [Key]
    public int ProductId { get; set; }
    [Required]
    public string ProductName { get; set; }
    [Required]
    public string Unit { get; set; } 
    [Required]
    public int ProductCategoryId { get; set; }
    [Required]
    public decimal Price { get; set; }

    public string Produces { get; set; } = null!;

    public virtual ICollection<FarmProduct> FarmProducts { get; set; } = new List<FarmProduct>();

    public virtual ProductCategory ProductCategory { get; set; } = null!;

    public virtual ICollection<ShoppingListItem> ShoppingListItems { get; set; } = new List<ShoppingListItem>();
}
