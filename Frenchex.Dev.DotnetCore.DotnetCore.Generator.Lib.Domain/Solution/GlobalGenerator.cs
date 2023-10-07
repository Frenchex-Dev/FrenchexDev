using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution.Global;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Solution;

public class GlobalGenerator : IGlobalGenerator
{
    public Task<IGlobalGenerationResult> GenerateAsync(
        IGlobal                  global
      , IGlobalGenerationContext globalGenerationContext
      , CancellationToken        cancellationToken = default
    )
    {
        throw new NotImplementedException();
    }
}