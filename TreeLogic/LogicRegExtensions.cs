using Microsoft.Extensions.DependencyInjection;
using TreeDB;

namespace TreeLogic;

public static class LogicRegExtensions
{
    public static void AddLogic(this IServiceCollection services)
    {
        services.AddMediator(o => o.ServiceLifetime = ServiceLifetime.Scoped);
        services.AddDB(new DbConfig() { ConnectionString = "" });

    }

    public static IServiceProvider ConfigureLogic(this IServiceProvider serviceProvider)
    {
        serviceProvider.ConfigureDB();
        
        return serviceProvider;
    }

}