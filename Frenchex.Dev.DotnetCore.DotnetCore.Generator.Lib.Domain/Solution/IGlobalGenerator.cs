using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution.Global;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Solution;

public interface IGlobalGenerator
{
    Task<IGlobalGenerationResult> GenerateAsync(
        IGlobal                  global
      , IGlobalGenerationContext globalGenerationContext
      , CancellationToken        cancellationToken = default
    );
}