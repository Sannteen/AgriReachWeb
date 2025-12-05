using System;
using System.Collections.Generic;

namespace AgriReachWeb.Models;

public partial class FarmProduct
{
    public int FarmProductId { get; set; }

    public int FarmId { get; set; }

    public int ProductId { get; set; }

    public decimal? BasePrice { get; set; }

    public string? AvailabilityStatus { get; set; }

    public DateTime? LastUpdated { get; set; }

    public string? Unit { get; set; }

    public virtual Farm Farm { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
