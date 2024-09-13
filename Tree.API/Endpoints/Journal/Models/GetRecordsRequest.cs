namespace Tree.API.Endpoints.Journal.Models;

public class GetRecordsRequest {
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    public string? Search { get; set; }
}
