using Microsoft.Extensions.DependencyInjection.Extensions;

using Tree.API.Endpoints.Interfaces;

namespace Tree.API.Extensions;

public static class EndpointsExtensions {

    public static IServiceCollection AddEndpoints(this IServiceCollection services) {
        var endpointsDescriptors = ServiceDescriptorExtensions.GetTransientDescriptors<IEndpoint>();

        services.TryAddEnumerable(endpointsDescriptors);

        return services;
    }

    public static IApplicationBuilder MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder) {
        var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

        foreach (var endpoint in endpoints) {
            endpoint.MapEndpoint(builder);
        }

        return app;
    }
}
