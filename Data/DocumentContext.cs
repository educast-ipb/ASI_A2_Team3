using Microsoft.EntityFrameworkCore;
using Educast.Models;

public class DocumentContext : DbContext
{
    public DocumentContext(DbContextOptions<DocumentContext> options)
        : base(options)
    {
    }

    public DbSet<Document> Documents { get; set; }
}