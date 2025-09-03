using Microsoft.EntityFrameworkCore;

namespace TreeDB;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Entities.Node> Node { get; set; } = null!;
    
    public DbSet<Entities.ErrorLog> ErrorLog { get; set; } = null!;
    
    public void Init()
    {
        Database.Migrate();
    }
}