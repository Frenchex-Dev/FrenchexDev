#region Licensing

// Licensing please read LICENSE.md

#endregion

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution.Global;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution;

public class SolutionDefinition : ISolutionDefinition
{
    public required string Name { get; set; }
    public required IGlobal Gobal { get; set; }
}
