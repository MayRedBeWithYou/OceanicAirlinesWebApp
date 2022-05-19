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
    }
}
