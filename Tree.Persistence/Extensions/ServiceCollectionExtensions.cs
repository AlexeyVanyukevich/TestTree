using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Tree.Persistence.Interfaces;
using Tree.Persistence.Options;
using Tree.Persistence.Repositories;

namespace Tree.Persistence.Extensions;
public static class ServiceCollectionExtensions {

    public static IServiceCollection AddPersistence(this IServiceCollection services) {

        return services
            .AddDatabase()
            .AddRepositories();
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services) {
        services.AddDbContext<ApplicationDbContext>((serviceProvider, builder) => {
            var options = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>()!.Value;
            builder.UseNpgsql(options.ConnectionString, contexOptions => {
                contexOptions.CommandTimeout(options.Timeout);
            });
        });

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services) {

        services.AddTransient<INodesRepository, NodesRepository>();
        services.AddTransient<IJournalRepository, JournalRepository>();

        return services;
    }
}
