using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

using Tree.Application.Interfaces;
using Tree.Application.Messaging.Behaviors;

namespace Tree.Application.Extensions;
public static class ServiceCollectionExtensions {

    public static IServiceCollection AddApplication(this IServiceCollection services) {

        services.AddMediatR(configuraiton => {
            configuraiton.RegisterServicesFromAssembly(Constants.Assembly);
            configuraiton.AddOpenBehavior(typeof(ValidationBehavior<,>));
            configuraiton.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));

        });

        services.AddValidatorsFromAssembly(Constants.Assembly, includeInternalTypes: true);

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
