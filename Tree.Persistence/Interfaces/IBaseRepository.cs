using Tree.Domain.Models;

namespace Tree.Persistence.Interfaces;
public interface IBaseRepository<TBase> where TBase : Base {
    void Add(TBase entity);
    void Update(TBase entity);
    void Delete(Guid id);
    Task<TBase?> GetByIdAsync(Guid id, bool tracking = false, CancellationToken cancellationToken = default);
}
