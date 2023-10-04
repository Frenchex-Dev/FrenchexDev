#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions;

public interface ISolutionGenerator
{
    Task<ISolutionGenerationResult> GenerateAsync(
        ISolutionDefinition solution
      , CancellationToken   cancellationToken = default
    );
}
