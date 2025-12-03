using System;
using System.Collections.Generic;

namespace AgriReachWeb.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int UserId { get; set; }

    public int FarmId { get; set; }

    public int Rating { get; set; }

    public string? ReviewText { get; set; }

    public DateTime? DatePosted { get; set; }

    public virtual Farm Farm { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
