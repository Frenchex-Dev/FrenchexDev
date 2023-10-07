#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions;

public class ProjectGenerationErrorResult : IProjectGenerationResult
{
    public required string Message { get; set; }
}
