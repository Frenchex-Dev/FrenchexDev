#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public class ExternalProjectReference : IExternalProjectReference
{
    public required string Name { get; set; }
    public required string Path { get; set; }

    /// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="UnauthorizedAccessException">Access to <see cref="Name" /> is denied.</exception>
    public string GetFullPath()
    {
        return new FileInfo($"{Path}\\{Name}.csproj").FullName;
    }

    /// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="UnauthorizedAccessException">Access to <see cref="Path" />is denied.</exception>
    public string GetFullDirectory()
    {
        return new FileInfo(Path).DirectoryName!;
    }
}
