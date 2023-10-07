#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain;

public interface IProjectGenerator
{
    Task<IProjectGenerationResult> GenerateAsync(
        IProjectDefinition        projectDefinition
      , IProjectGenerationContext projectGenerationContext
      , CancellationToken         cancellationToken = default
    );
}

public class ProjectGenerator : IProjectGenerator
{
    public async Task<IProjectGenerationResult> GenerateAsync(
        IProjectDefinition        projectDefinition
      , IProjectGenerationContext projectGenerationContext
      , CancellationToken         cancellationToken = default
    )
    {
        throw new NotImplementedException();
    }
}