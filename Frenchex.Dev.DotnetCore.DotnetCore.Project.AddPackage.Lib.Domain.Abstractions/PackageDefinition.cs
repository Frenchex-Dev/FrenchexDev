#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.AddPackage.Lib.Domain.Abstractions;

public class PackageDefinition : IPackageDefinition
{
    public required string Name    { get; set; }
    public required string Version { get; set; }
}
