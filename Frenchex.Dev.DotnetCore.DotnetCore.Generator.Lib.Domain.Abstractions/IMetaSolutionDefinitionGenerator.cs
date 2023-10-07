#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public interface IMetaSolutionDefinitionGenerator
{
    Task<IMetaSolutionDefinitionGenerationResult> GenerateAsync(
        IMetaSolutionDefinition metaSolutionDefinition
      , IGenerationContext      generationContext
      , CancellationToken       cancellationToken = default
    );
}