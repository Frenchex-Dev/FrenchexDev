#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Project.AddPackage.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.AddPackage.Lib.Domain;

public interface IAddPackageService
{
    Task<IAddPackageResult> AddAsync(
        ICsProj            project
      , IPackageDefinition package
      , CancellationToken  cancellationToken = default
    );
}
