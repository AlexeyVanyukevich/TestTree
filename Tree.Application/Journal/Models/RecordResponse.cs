using System.Text.Json.Serialization;

using Tree.Application.Models;
using Tree.Domain.Models;

namespace Tree.Application.Journal.Models;
public class RecordResponse : BaseResponse<Record> {
    public string EventId { get; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Text { get; }
    public DateTime CreatedAt { get; }
    public RecordResponse(Record model) : base(model) {
        EventId = model.EventId;
        Text = model.Text;
        CreatedAt = model.CreatedAt;
    }
}
