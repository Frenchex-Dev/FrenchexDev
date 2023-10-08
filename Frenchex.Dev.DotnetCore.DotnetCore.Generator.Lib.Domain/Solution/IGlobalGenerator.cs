#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution.Global;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Solution;

public interface IGlobalGenerator
{
    Task<IGlobalGenerationResult> GenerateAsync(
        IGlobal                  global
      , IGlobalGenerationContext globalGenerationContext
      , CancellationToken        cancellationToken = default
    );
}
