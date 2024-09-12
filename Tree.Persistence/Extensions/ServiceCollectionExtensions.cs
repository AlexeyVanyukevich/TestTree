using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Tree.Persistence.Options;

namespace Tree.Persistence.Extensions;
public static class ServiceCollectionExtensions {

    public static IServiceCollection AddPersistence(this IServiceCollection services) {

        return services.AddDatabase();
    }

    private static IServiceCollection AddDatabase(this  IServiceCollection services) {
        services.AddDbContext<ApplicationDbContext>((serviceProvider, builder) => {
            var options = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>()!.Value;
            builder.UseNpgsql(options.ConnectionString, contexOptions => {
                contexOptions.CommandTimeout(options.Timeout);
                contexOptions.EnableRetryOnFailure(options.MaxRetryCount);
            });
        });

        return services;
    }
}
