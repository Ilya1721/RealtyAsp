using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Realty.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Realty.DB
{
    public class RealtyContext : IdentityDbContext<ApplicationUser>
    {
        public RealtyContext() : base("RealtyContext") { }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<FlatUserPivot> FlatUserPivots { get; set; }
        public DbSet<HeaterType> HeaterTypes { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PhotoFlatPivot> PhotoFlatPivots { get; set; }
        public DbSet<WishFlatUserPivot> WishFlatUserPivots { get; set; }

        public static RealtyContext Create()
        {
            return new RealtyContext();
        }
    }
}