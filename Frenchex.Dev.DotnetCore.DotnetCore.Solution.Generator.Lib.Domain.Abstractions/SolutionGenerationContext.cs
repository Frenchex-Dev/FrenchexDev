#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions;

public class SolutionGenerationContext : ISolutionGenerationContext
{
    public required string Path { get; set; }
}
