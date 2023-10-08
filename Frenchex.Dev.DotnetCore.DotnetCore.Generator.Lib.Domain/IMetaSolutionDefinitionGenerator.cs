#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain;

public interface IMetaSolutionDefinitionGenerator
{
    Task<IMetaSolutionDefinitionGenerationResult> GenerateAsync(
        IMetaSolutionDefinition        metaSolutionDefinition
      , IMetaSolutionGenerationContext metaSolutionGenerationContext
      , CancellationToken              cancellationToken = default
    );
}
