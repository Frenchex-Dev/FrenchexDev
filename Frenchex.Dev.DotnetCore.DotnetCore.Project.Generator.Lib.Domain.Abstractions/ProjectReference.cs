#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions;

public class ProjectReference : IProjectReference
{
    public ICsProjPath CsProjPath { get; }
}
