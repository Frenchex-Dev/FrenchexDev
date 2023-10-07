#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public class CsProj : ICsProj
{
    public required string Name           { get; set; }
    public required string SolutionFolder { get; set; }
}
