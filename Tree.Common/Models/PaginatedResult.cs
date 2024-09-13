namespace Tree.Persistence.Models;
public class PaginatedResult<TResult> {
    public int Count { get; init; }
    public int Skip { get; init; }
    public List<TResult> Items { get; init; }
}
