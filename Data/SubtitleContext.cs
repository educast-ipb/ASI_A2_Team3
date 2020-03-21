using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Educast.Models;

public class SubtitleContext : DbContext
{
    public SubtitleContext(DbContextOptions<SubtitleContext> options)
        : base(options)
    {
    }

    public DbSet<Educast.Models.Subtitle> Subtitle { get; set; }
}
