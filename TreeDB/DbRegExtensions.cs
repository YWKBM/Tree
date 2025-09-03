using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace TreeDB;

public static class DbRegExtensions
{
    public static IServiceCollection AddDB(this IServiceCollection services,  NpgsqlDataSource dataSource)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(dataSource, x => x.MigrationsAssembly("TreeDB"));
        });
        
        return services;        
    }

    public static IServiceProvider ConfigureDB(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            scope.ServiceProvider.GetRequiredService<AppDbContext>().Init();

            return serviceProvider;
        }
    }
}