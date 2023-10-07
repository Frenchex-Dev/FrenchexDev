#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.AddProject.Lib.Domain.Abstractions;

public class CsProj : ICsProj
{
    public required string  Path           { get; set; }
    public          string? SolutionFolder { get; set; }

    public bool HasSolutionFolder => !string.IsNullOrEmpty(SolutionFolder);
}
