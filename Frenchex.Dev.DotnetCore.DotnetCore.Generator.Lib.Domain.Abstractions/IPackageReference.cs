#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public interface IPackageReference
{
    string  Name       { get; }
    string? Version    { get; }
    bool    HasVersion { get; }
}
