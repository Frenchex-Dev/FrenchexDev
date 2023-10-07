#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public class SolutionDefinition : ISolutionDefinition
{
    public required string  Name  { get; set; }
    public required IGlobal Gobal { get; set; }
}
