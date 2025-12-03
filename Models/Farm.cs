using System;
using System.Collections.Generic;

namespace AgriReachWeb.Models;

public partial class Farm
{
    public int FarmId { get; set; }

    public int UserId { get; set; }

    public string FarmName { get; set; } = null!;

    public string Parish { get; set; } = null!;

    public string? Address { get; set; }

    public string? Description { get; set; }

    public DateTime? DateRegistered { get; set; }

    public virtual ICollection<Produce> Produces { get; set; } = new List<Produce>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual User User { get; set; } = null!;
}
