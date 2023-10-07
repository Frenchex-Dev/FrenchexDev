#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.AddProject.Lib.Domain.Abstractions;

public class AddProjectErrorResult : IAddProjectResult
{
    public required string Error { get; set; }
}
