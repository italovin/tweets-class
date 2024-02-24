using blazor_test.Models.ORM;
using Microsoft.EntityFrameworkCore;

namespace blazor_test.Data;

public class ConnectionDbContext:DbContext{

    public DbSet<Phrase> Phrases { get; set; }
    public DbSet<Labeling> Labelings { get; set; }
    public DbSet<AccessKey> AccessKeys { get; set; }
    public ConnectionDbContext(DbContextOptions<ConnectionDbContext> options):base(options)
    {
    }
}