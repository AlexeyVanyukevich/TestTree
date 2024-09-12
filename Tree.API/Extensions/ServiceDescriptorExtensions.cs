namespace Tree.API.Extensions;

internal static class ServiceDescriptorExtensions {

    public static ServiceDescriptor[] GetTransientDescriptors<TInerface>() {
        var interfaceType = typeof(TInerface);

        return Constants.Assemly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                            type.IsAssignableTo(interfaceType))
            .Select(type => ServiceDescriptor.Transient(interfaceType, type))
            .ToArray();
    }
}
