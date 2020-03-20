using Microsoft.EntityFrameworkCore;
using Educast.Models;

public class ChapterContext : DbContext
{
    public ChapterContext(DbContextOptions<ChapterContext> options)
        : base(options)
    {
    }

    public DbSet<Chapter> Chapters { get; set; }
}