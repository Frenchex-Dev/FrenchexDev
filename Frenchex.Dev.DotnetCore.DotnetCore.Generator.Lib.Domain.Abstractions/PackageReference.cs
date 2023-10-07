#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public class PackageReference : IPackageReference
{
    public required string  Name       { get; set; }
    public required string? Version    { get; set; }
    public          bool    HasVersion => !string.IsNullOrEmpty(Version);
}
