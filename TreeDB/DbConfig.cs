using Npgsql;

namespace TreeDB;

public class DbConfig
{
    public string ConnectionString { get; set; } = string.Empty;

    public required NpgsqlDataSource DataSource { get; set; }
    
}