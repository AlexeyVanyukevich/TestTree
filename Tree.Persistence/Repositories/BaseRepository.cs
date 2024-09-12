using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

using Tree.Domain.Models;
using Tree.Persistence.Interfaces;

namespace Tree.Persistence.Repositories;
internal class BaseRepository<TBase> : IBaseRepository<TBase> where TBase : Base, new() {

    private readonly DbSet<TBase> _dbSet;

    public BaseRepository(DbContext context) {
        _dbSet = context.Set<TBase>();
    }

    public void Add(TBase entity) {
        _dbSet.Add(entity);
    }

    public void Update(TBase entity) {
        _dbSet.Update(entity);
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

    public void Delete(Guid id) {
        var entity = new TBase { Id = id };
        _dbSet.Attach(entity);
        _dbSet.Remove(entity);
    }
}
