using Tree.API.Endpoints.Interfaces;

namespace Tree.API.Endpoints;

public abstract class BaseEndpoint : IEndpoint {
    public string BasePath { get; init; }
    protected BaseEndpoint(string basePath) {
        BasePath = basePath;
    }

    public void MapEndpoint(IEndpointRouteBuilder app) {
        var builder = string.IsNullOrEmpty(BasePath) ? app : app.MapGroup(BasePath.ToLower());
        MapEndpointInternal(builder);
    }

    protected abstract void MapEndpointInternal(IEndpointRouteBuilder app);
}
