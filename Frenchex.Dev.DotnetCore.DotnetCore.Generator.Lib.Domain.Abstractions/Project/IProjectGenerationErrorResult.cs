#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project;

public class IProjectGenerationErrorResult : IProjectGenerationResult
{
    public required string Error { get; set; }
    public required string Message { get; set; }
}
