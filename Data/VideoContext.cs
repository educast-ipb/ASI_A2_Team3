using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Educast.Models;

    public class VideoContext : DbContext
    {
        public VideoContext (DbContextOptions<VideoContext> options)
            : base(options)
        {
        }

        public DbSet<Educast.Models.Video> Video { get; set; }
    }
