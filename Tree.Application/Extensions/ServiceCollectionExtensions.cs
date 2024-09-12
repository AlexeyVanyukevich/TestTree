using Microsoft.Extensions.DependencyInjection;

using Tree.Application.Interfaces;

namespace Tree.Application.Extensions;
public static class ServiceCollectionExtensions {

    public static IServiceCollection AddApplication(this IServiceCollection services) {

        services.AddMediatR(configuraiton => {
            configuraiton.RegisterServicesFromAssembly(Constants.Assembly);

        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
