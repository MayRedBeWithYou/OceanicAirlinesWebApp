using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OceanicAirlinesWebApp.Models;

namespace OceanicAirlinesWebApp.Data
{
    public class OceanicAirlinesWebAppContext : DbContext
    {
        public OceanicAirlinesWebAppContext (DbContextOptions<OceanicAirlinesWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<OceanicAirlinesWebApp.Models.Parcel>? Parcel { get; set; }
        public DbSet<OceanicAirlinesWebApp.Models.User>? User { get; set; }
        public DbSet<OceanicAirlinesWebApp.Models.User_Parcel>? User_Parcel { get; set; }
        public DbSet<OceanicAirlinesWebApp.Models.Category>? Category { get; set; }
    }
}
