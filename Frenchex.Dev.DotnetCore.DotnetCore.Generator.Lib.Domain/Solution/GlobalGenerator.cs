#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Text.Json;
using Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Domain;
using Frenchex.Dev.DotnetCore.CodeGeneration.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution.Global;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Solution;

public class GlobalGenerator(
    IGeneratedCodeWriter generatedCodeWriter
) : IGlobalGenerator
{
    public async Task<IGlobalGenerationResult> GenerateAsync(
        IGlobal                  global
      , IGlobalGenerationContext globalGenerationContext
      , CancellationToken        cancellationToken = default
    )
    {
        try
        {
            var generatedFile = new GeneratedFile
                                {
                                    Content = JsonSerializer.Serialize(
                                                                       (Global)global
                                                                     , new JsonSerializerOptions
                                                                       {
                                                                           WriteIndented = true
                                                                       })
                                  , Extension = ".json"
                                  , FileName  = "global.json"
                                  , Path      = $"{globalGenerationContext.Path}\\global.json"
                                };

            await generatedCodeWriter.WriteAsync(
                                                 new List<IGeneratedFile>
                                                 {
                                                     generatedFile
                                                 }
                                               , cancellationToken);

            return new GlobalGenerationOkResult();
        }
        catch (Exception ex)
        {
            return new GlobalGenerationErrorResult
                   {
                       Error     = ex.Message
                     , Exception = ex
                   };
        }
    }
}
