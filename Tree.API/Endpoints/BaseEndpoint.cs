using Tree.API.Endpoints.Interfaces;

namespace Tree.API.Endpoints;

public abstract class BaseEndpoint : IEndpoint {
    public string BasePath { get; init; }
    protected BaseEndpoint(string basePath) {
        BasePath = basePath;
    }

    public void MapEndpoint(IEndpointRouteBuilder app) {
        var builder = string.IsNullOrEmpty(BasePath) ? app : app.MapGroup(BasePath.ToLower());
        var conventionBuilder = MapEndpointInternal(builder);

        conventionBuilder.WithTags(BasePath);
    }

    protected abstract IEndpointConventionBuilder MapEndpointInternal(IEndpointRouteBuilder app);
}
