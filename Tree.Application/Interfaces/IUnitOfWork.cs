using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tree.Persistence.Interfaces;

namespace Tree.Application.Interfaces;
internal interface IUnitOfWork {

    INodesRepository Nodes { get; }
    IJournalRepository Journal { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
