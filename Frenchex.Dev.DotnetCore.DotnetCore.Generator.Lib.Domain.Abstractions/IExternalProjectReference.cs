#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public interface IExternalProjectReference
{
    string Name { get; }
    string Path { get; }
    string GetFullPath();
    string GetFullDirectory();
}
