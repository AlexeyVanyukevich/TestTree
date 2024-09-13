using Microsoft.EntityFrameworkCore.Diagnostics;

using Tree.Domain.Interfaces;

namespace Tree.Persistence.Interceptors;
internal sealed class AddInterceptor
    : SaveChangesInterceptor {

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default) {
        var dbContext = eventData.Context;

        if (dbContext is null) {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var addedEntities = dbContext.ChangeTracker
            .Entries<IBase>()
            .Where(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added);

        foreach (var entity in addedEntities) {
            entity.Property(e => e.Id).CurrentValue = Guid.NewGuid();
        }


        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
