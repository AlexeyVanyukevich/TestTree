using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Tree.Persistence.Services;
internal class MigrationHostedService : BackgroundService {
    private readonly IServiceProvider _serviceProvider;

    public MigrationHostedService(IServiceProvider serviceProvider) {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken) {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        try {
            await dbContext.Database.MigrateAsync(cancellationToken);
        } catch (Exception ex) {
            Console.WriteLine($"Error applying migrations: {ex.Message}");
        }
    }
}