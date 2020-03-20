using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Educast.Models;

    public class BrandingContext : DbContext
    {
        public BrandingContext (DbContextOptions<BrandingContext> options)
            : base(options)
        {
        }

        public DbSet<Educast.Models.Branding> Branding { get; set; }
    }
