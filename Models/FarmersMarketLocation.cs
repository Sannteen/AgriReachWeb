using System;
using System.Collections.Generic;

namespace AgriReachWeb.Models;

public partial class FarmersMarketLocation
{
    public int LocationId { get; set; }

    public string LocationName { get; set; } = null!;

    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();
}
