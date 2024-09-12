using Tree.Domain.Models;
using Tree.Persistence.Interfaces;

namespace Tree.Persistence.Repositories;
internal class BaseRepository<TBase> : IBaseRepository<TBase> where TBase : Base {
}
