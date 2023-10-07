#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution;

public class SolutionGenerationContext : ISolutionGenerationContext
{
    public required string Path { get; set; }
}
