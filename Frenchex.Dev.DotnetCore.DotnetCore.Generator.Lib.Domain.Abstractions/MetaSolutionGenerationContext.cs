#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public class MetaSolutionGenerationContext : IMetaSolutionGenerationContext
{
    public required string Path { get; set; }
}
