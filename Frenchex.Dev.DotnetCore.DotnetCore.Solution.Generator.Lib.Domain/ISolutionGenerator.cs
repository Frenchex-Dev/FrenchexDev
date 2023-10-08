#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain;

public interface ISolutionGenerator
{
    Task<ISolutionGenerationResult> GenerateAsync(
        ISolutionDefinition        solution
      , ISolutionGenerationContext solutionGenerationContext
      , CancellationToken          cancellationToken = default
    );
}
