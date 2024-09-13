using Tree.Application.Interfaces;

namespace Tree.Application.Services;
internal sealed class GuidCorrelationIdGenerator
    : ICorrelationIdGenerator {
    private string _correlationId = Guid.NewGuid().ToString();
    public string Get() => _correlationId;

    public void Set(string correlationId) {
        _correlationId = correlationId;
    }
}
