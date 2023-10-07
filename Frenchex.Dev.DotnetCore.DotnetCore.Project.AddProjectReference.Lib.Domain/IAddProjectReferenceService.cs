#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Project.AddProjectReference.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Project.AddProjectReference.Lib.Domain;

public interface IAddProjectReferenceService
{
    Task<IAddProjectReferenceResult> AddAsync(
        ICsProj           targetProject
      , ICsProj           sourceProject
      , CancellationToken cancellationToken = default
    );
}
