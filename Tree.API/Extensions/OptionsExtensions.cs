using Tree.API.Setups;

namespace Tree.API.Extensions;

public static class OptionsExtensions {
    public static IServiceCollection AddOptionsSetups(this IServiceCollection services) {

        services.ConfigureOptions<DatabaseOptionsSetup>();

        return services;
    }
}
