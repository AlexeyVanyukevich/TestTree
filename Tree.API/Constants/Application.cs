using System.Reflection;

namespace Tree.API.Constants;

internal static class Application {
    public static readonly Assembly Assembly = typeof(Application).Assembly;
    public const string ApiGroup = "api";
}
