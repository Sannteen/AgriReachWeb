using System;
using System.Collections.Generic;

namespace AgriReachWeb.Models;

public partial class Area
{
    public int AreaId { get; set; }

    public string AreaName { get; set; } = null!;

    public int LocationId { get; set; }

    public virtual ICollection<Farm> Farms { get; set; } = new List<Farm>();

    public virtual FarmersMarketLocation Location { get; set; } = null!;
}
