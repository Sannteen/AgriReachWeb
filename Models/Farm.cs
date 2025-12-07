using System;
using System.Collections.Generic;

namespace AgriReachWeb.Models;

    public partial class Farm
    {
        public int FarmId { get; set; }
        public int UserId { get; set; }

        public string? FarmName { get; set; } = null!;

        public string? Address { get; set; }
        public string? Description { get; set; }
        public DateTime? DateRegistered { get; set; }

        public int? AreaId { get; set; }                    //Made nullable
        public string? Parish { get; set; }                 //Made nullable
        public string? Produces { get; set; }               //Made nullable
        public string? Product { get; set; }                // Made nullable

        public virtual Area? Area { get; set; }             //Navigation nullable

        public virtual ICollection<FarmProduct> FarmProducts { get; set; } = new List<FarmProduct>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }