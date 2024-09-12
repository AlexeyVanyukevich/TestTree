using Microsoft.Extensions.DependencyInjection;

namespace Tree.Persistence.Extensions;
public static class ServiceCollectionExtensions {

    public static IServiceCollection AddPersistence(this IServiceCollection services) {

        return services;
    }
}
