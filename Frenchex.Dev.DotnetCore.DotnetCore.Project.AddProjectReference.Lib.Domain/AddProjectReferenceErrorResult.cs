#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.AddProjectReference.Lib.Domain;

public class AddProjectReferenceErrorResult : IAddProjectReferenceResult
{
    public required string Error { get; init; }
}
