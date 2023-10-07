#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution.Global;
using DotnetSolutionDefinition = Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions.SolutionDefinition;
using DotnetSolutionGenerationContext
    = Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions.SolutionGenerationContext;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Solution;

public class SolutionGenerator(
    IGlobalGenerator                                                         globalGenerator
  , DotnetCore.Solution.Generator.Lib.Domain.Abstractions.ISolutionGenerator dotnetSolutionGenerator
) : ISolutionGenerator
{
    /// <summary>
    /// </summary>
    /// <param name="solutionDefinition"></param>
    /// <param name="solutionGenerationContext"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="IOException">The directory cannot be created.</exception>
    public async Task<ISolutionGenerationResult> GenerateAsync(
        ISolutionDefinition        solutionDefinition
      , ISolutionGenerationContext solutionGenerationContext
      , CancellationToken          cancellationToken = default
    )
    {
        var solutionGenerationContextDirInfo = new DirectoryInfo(solutionGenerationContext.Path);

        if (!solutionGenerationContextDirInfo.Exists) solutionGenerationContextDirInfo.Create();

        var dotnetSolutionGenerationResponse = await dotnetSolutionGenerator.GenerateAsync(
                                                                                           new DotnetSolutionDefinition
                                                                                           {
                                                                                               Name = solutionDefinition.Name
                                                                                           }
                                                                                         , new DotnetSolutionGenerationContext
                                                                                           {
                                                                                               Path = solutionGenerationContextDirInfo
                                                                                                   .FullName
                                                                                           }
                                                                                         , cancellationToken);

        if (dotnetSolutionGenerationResponse is SolutionGenerationErrorResult solutionGenerationErrorResult)
            return new SolutionGenerationErrorResult
                   {
                       Error   = "Error while creating solution"
                     , Message = solutionGenerationErrorResult.Error
                   };

        var globalGenerationResponse = await globalGenerator.GenerateAsync(
                                                                           solutionDefinition.Gobal
                                                                         , new GlobalGenerationContext
                                                                           {
                                                                               Path = solutionGenerationContextDirInfo.FullName
                                                                           }
                                                                         , cancellationToken);

        if (globalGenerationResponse is GlobalGenerationErrorResult globalGenerationErrorResult)
            return new SolutionGenerationErrorResult
                   {
                       Error   = "Error while creating global.json"
                     , Message = globalGenerationErrorResult.Error
                   };

        return new SolutionGenerationOkResult();
    }
}
