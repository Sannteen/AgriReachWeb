using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgriReachWeb.Models;

public partial class FarmersMarket

{
    [Key]
    public int MarketId { get; set; }

    public string MarketName { get; set; } = null!;

    public int AreaId { get; set; }

    public string OpeningDays { get; set; } = null!;

    public string Address { get; set; } = null!;
}
