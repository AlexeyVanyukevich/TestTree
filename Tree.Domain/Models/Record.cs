using Tree.Domain.Primitives;

namespace Tree.Domain.Models;
public class Record : Base, IAuditable {
    public DateTime CreatedAt { get; set; }
    public string EventId { get; set; }
    public string Text { get; set; }

}
