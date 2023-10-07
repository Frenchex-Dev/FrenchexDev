#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain;

public interface ISolutionGenerator
{
    Task<ISolutionGenerationResult> GenerateAsync(
        ISolutionDefinition        solutionDefinition
      , ISolutionGenerationContext solutionGenerationContext
      , CancellationToken          cancellationToken = default
    );
}

public class SolutionGenerator : ISolutionGenerator
{
    public async Task<ISolutionGenerationResult> GenerateAsync(
        ISolutionDefinition        solutionDefinition
      , ISolutionGenerationContext solutionGenerationContext
      , CancellationToken          cancellationToken = default
    )
    {
        throw new NotImplementedException();
    }
}