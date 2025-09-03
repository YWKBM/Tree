using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using TreeDB;
using TreeLogic.Services;

namespace TreeLogic;

public static class LogicRegExtensions
{
    public static void AddLogic(this IServiceCollection services, NpgsqlDataSource dataSource)
    {
        services.AddMediator(o => o.ServiceLifetime = ServiceLifetime.Scoped);
        services.AddDB(dataSource);

        services.AddScoped<ExceptionService>();
    }

    public static IServiceProvider ConfigureLogic(this IServiceProvider serviceProvider)
    {
        serviceProvider.ConfigureDB();
        
        return serviceProvider;
    }

}