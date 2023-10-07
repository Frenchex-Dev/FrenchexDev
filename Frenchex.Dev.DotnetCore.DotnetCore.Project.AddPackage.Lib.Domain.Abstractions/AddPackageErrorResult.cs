#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.AddPackage.Lib.Domain.Abstractions;

public class AddPackageErrorResult : IAddPackageResult
{
    public required string Error { get; set; }
}
