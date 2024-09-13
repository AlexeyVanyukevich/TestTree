using Microsoft.Extensions.DependencyInjection;
using Tree.Common.Interfaces;
using Tree.Common.Provider;

namespace Tree.Common.Extensions;
public static class ServiceCollectionExtensions {

    public static IServiceCollection AddTimeProvider(this IServiceCollection services) {

        services.AddSingleton<ITimeProvider, SystemTimeProvider>();
        
        return services;
    }
}
