using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using TreeDB;

namespace TreeLogic;

public static class LogicRegExtensions
{
    public static void AddLogic(this IServiceCollection services, NpgsqlDataSource dataSource)
    {
        services.AddMediator(o => o.ServiceLifetime = ServiceLifetime.Scoped);
        services.AddDB(dataSource);

    }

    public static IServiceProvider ConfigureLogic(this IServiceProvider serviceProvider)
    {
        serviceProvider.ConfigureDB();
        
        return serviceProvider;
    }

}