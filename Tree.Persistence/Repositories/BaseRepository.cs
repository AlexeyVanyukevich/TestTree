using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

using Tree.Domain.Models;
using Tree.Persistence.Interfaces;

namespace Tree.Persistence.Repositories;
internal class BaseRepository<TBase> : IBaseRepository<TBase> where TBase : Base, new() {

    protected readonly DbSet<TBase> DbSet;

    public BaseRepository(DbContext context) {
        DbSet = context.Set<TBase>();
    }

    public void Add(TBase entity) {
        DbSet.Add(entity);
    }

    public void Update(TBase entity) {
        DbSet.Update(entity);
    }

    public Task<TBase?> GetByIdAsync(Guid id, bool tracking = false, CancellationToken cancellationToken = default) {
        return FirstOrDefaultAsync(entity => entity.Id == id, tracking, cancellationToken);
    }

    protected Task<bool> AnyAsync(Expression<Func<TBase, bool>> predicate, CancellationToken cancellationToken = default) {
        return Query(false).AnyAsync(predicate, cancellationToken);
    }

    protected Task<TBase?> FirstOrDefaultAsync(Expression<Func<TBase, bool>> predicate, bool tracking = false, CancellationToken cancellationToken = default) {
        return Query(tracking).FirstOrDefaultAsync(predicate, cancellationToken);
    }

    protected virtual IQueryable<TBase> Query(bool tracking) {
        return tracking ? DbSet : DbSet.AsNoTracking();
    }

    public void Delete(Guid id) {
        var entity = new TBase { Id = id };
        DbSet.Attach(entity);
        DbSet.Remove(entity);
    }
}
