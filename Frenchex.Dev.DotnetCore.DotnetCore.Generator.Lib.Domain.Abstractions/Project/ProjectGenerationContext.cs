#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project;

public class ProjectGenerationContext : IProjectGenerationContext
{
    public required string Path { get; set; }
}
