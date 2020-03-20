using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educast.Data
{
    public class CanalContext : DbContext
    {
        public CanalContext(DbContextOptions<CanalContext> options)
            : base(options)
        {
        }

        public DbSet<Educast.Models.Canal> Canal { get; set; }
    }
}
