#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution;

public class SolutionGenerationErrorResult : ISolutionGenerationResult
{
    public required string Error { get; set; }
    public required string Message { get; set; }
}
