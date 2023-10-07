#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.AddProject.Lib.Domain.Abstractions;

public interface ICsProj
{
    string  Path           { get; }
    string? SolutionFolder { get; }

    bool HasSolutionFolder { get; }
}
