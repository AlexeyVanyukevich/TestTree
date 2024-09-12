using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq.Expressions;

using Tree.Domain.Models;
using Tree.Persistence.Interfaces;

namespace Tree.Persistence.Repositories;
internal class BaseRepository<TBase> : IBaseRepository<TBase> where TBase : Base {

    private readonly DbSet<TBase> _dbSet;

    public BaseRepository(DbContext context) {
        _dbSet = context.Set<TBase>();
    }

    public void Add(TBase entity) {
        _dbSet.Add(entity);
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
        return tracking ? _dbSet : _dbSet.AsNoTracking();
    }
}
