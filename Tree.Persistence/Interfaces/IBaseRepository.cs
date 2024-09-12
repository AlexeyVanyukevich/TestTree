using System.Linq.Expressions;
using System.Threading.Tasks;

using Tree.Domain.Models;

namespace Tree.Persistence.Interfaces;
public interface IBaseRepository<TBase> where TBase : Base {
    void Add(TBase entity);
    Task<TBase?> GetByIdAsync(Guid id, bool tracking = false, CancellationToken cancellationToken = default)
}
