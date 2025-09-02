using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace TreeDB;

public class AppDbContext(
    DbConfig dbConfig) : DbContext
{
    public DbSet<Entities.Node> Nodes { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(dbConfig.ConnectionString);
        var dataSource = dataSourceBuilder.Build();
        
        optionsBuilder.UseNpgsql(dataSource, x =>  x.MigrationsAssembly("TreeDB"));
        base.OnConfiguring(optionsBuilder);
    }

    public void Init()
    {
        Database.Migrate();
    }
}