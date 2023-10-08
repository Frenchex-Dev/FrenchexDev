#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Project;

public interface IProjectGenerator
{
    Task<IProjectGenerationResult> GenerateAsync(
        IProjectDefinition        projectDefinition
      , IProjectGenerationContext projectGenerationContext
      , CancellationToken         cancellationToken = default
    );
}
