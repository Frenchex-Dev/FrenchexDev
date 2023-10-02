namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions;

public class SolutionDefinition : ISolutionDefinition
{
    public required string Name { get; set; }
    public required string Path { get; set; }
}
