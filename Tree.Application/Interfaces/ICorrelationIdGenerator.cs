namespace Tree.Application.Interfaces;
public interface ICorrelationIdGenerator {
    string Get();
    void Set(string correlationId);
}
