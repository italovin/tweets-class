using Models.ORM;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class ConnectionDbContext:DbContext{
    public ConnectionDbContext(){
    }
    public ConnectionDbContext(DbContextOptions<ConnectionDbContext> options): base(options){
        
    }
    public DbSet<Phrase> Phrases { get; set; }
    public DbSet<Labeling> Labelings { get; set; }
    public DbSet<AccessKey> AccessKeys { get; set; }
}