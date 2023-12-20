using blazor_test.Models;
using Microsoft.EntityFrameworkCore;

namespace blazor_test.Data;

public class ConnectionDbContext:DbContext{

    public DbSet<Phrase> Phrases { get; set; }
    public DbSet<Labeling> Labelings { get; set; }
    public ConnectionDbContext(DbContextOptions<ConnectionDbContext> options):base(options)
    {
    }
}