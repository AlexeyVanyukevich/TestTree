using Tree.Common.Interfaces;

namespace Tree.Common.Provider;
internal sealed class SystemTimeProvider : ITimeProvider {
    public DateTime GetUtcNow() {
        return DateTime.UtcNow;
    }
}
