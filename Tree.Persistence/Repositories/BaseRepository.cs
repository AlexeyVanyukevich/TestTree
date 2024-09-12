using Microsoft.EntityFrameworkCore;

using Tree.Domain.Models;
using Tree.Persistence.Interfaces;

namespace Tree.Persistence.Repositories;
internal class BaseRepository<TBase> : IBaseRepository<TBase> where TBase : Base {

    private readonly DbSet<TBase> _dbSet;

    public BaseRepository(DbContext context) {
        _dbSet = context.Set<TBase>();
    }
}
