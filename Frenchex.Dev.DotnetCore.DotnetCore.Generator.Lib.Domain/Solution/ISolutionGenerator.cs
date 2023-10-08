#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Solution;

public interface ISolutionGenerator
{
    Task<ISolutionGenerationResult> GenerateAsync(
        ISolutionDefinition        solutionDefinition
      , ISolutionGenerationContext solutionGenerationContext
      , CancellationToken          cancellationToken = default
    );
}
