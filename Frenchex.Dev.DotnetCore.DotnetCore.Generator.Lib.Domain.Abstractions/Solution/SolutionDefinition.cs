#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution.Global;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution;

public class SolutionDefinition : ISolutionDefinition
{
    public required string  Name  { get; set; }
    public required IGlobal Gobal { get; set; }
}
