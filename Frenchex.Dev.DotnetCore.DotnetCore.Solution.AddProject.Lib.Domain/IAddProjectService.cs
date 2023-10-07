#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Solution.AddProject.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.AddProject.Lib.Domain;

public interface IAddProjectService
{
    Task<IAddProjectResult> AddAsync(
        ISolution         solution
      , ICsProj           project
      , CancellationToken cancellationToken = default
    );
}
