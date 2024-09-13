using Tree.Domain.Models;

namespace Tree.Persistence.Interfaces;
public interface INodesRepository : IBaseRepository<Node> {

    INodesRepository Configure(NodesRepositoryConfiguration configuration);
    Task<Node?> ToTreeAsync(string name, CancellationToken cancellationToken = default);
    Task<bool> RootExistsAsync(string name, CancellationToken cancellationToken = default);
}


public class NodesRepositoryConfiguration {
    public bool IncludeParent { get; set; }
    public bool IncludeChildren { get; set; }
    public bool IncludeParentChildren { get; set; }
}