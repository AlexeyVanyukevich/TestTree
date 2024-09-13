using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using Tree.Common.Interfaces;
using Tree.Domain.Primitives;


namespace Tree.Persistence.Interceptors;
internal sealed class AuditableInterceptor : SaveChangesInterceptor {
    private readonly ITimeProvider _timeProvider;
    public AuditableInterceptor(ITimeProvider timeProvider) {
        _timeProvider = timeProvider;
    }
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default) {
        var dbContext = eventData.Context;

        if (dbContext is null) {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var entities = dbContext.ChangeTracker
            .Entries<IAuditable>()
            .Where(e => e.State == EntityState.Added);

        var now = _timeProvider.GetUtcNow();

        foreach (var entity in entities) {
            entity.Property(e => e.CreatedAt).CurrentValue = now;
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
