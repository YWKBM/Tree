using Microsoft.Extensions.DependencyInjection;
using TreeDB;

namespace TreeLogic;

public static class LogicRegExtensions
{
    public static void AddLogic(this IServiceCollection services)
    {
        services.AddMediator(o => o.ServiceLifetime = ServiceLifetime.Scoped);
        services.AddDB(new DbConfig() { ConnectionString = "Host=localhost;Port=5432;Database=Tree;Username=postgres;Password=123456" });

    }

    public static IServiceProvider ConfigureLogic(this IServiceProvider serviceProvider)
    {
        serviceProvider.ConfigureDB();
        
        return serviceProvider;
    }

}