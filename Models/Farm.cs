using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;

namespace AgriReachWeb.Models;

public partial class Farm
{
    public int FarmId { get; set; }

    public int UserId { get; set; }

    public string FarmName { get; set; } = null!;

    public string? Address { get; set; }

    public string? Description { get; set; }

    public DateTime? DateRegistered { get; set; }

    public int AreaId { get; set; }

    public string? Parish {  get; set; }

    public virtual Area Area { get; set; } = null!;

    public string? Produces { get; set; }
    
    public string? Product { get; set; }

    public virtual ICollection<FarmProduct> FarmProducts { get; set; } = new List<FarmProduct>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
