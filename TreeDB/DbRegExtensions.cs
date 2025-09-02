using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TreeDB;

public static class DbRegExtensions
{
    public static IServiceCollection AddDB(this IServiceCollection services, DbConfig dbConfig)
    {
        services.AddSingleton(dbConfig);
        services.AddDbContext<AppDbContext>();
        return services;
    }

    public static IServiceProvider ConfigureDB(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        scope.ServiceProvider.GetRequiredService<AppDbContext>().Init();

        return serviceProvider;
    }
}