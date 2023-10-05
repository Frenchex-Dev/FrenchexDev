#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Text.Json;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

public class ProjectTemplateGenerator : IProjectTemplateGenerator
{
    public async Task GenerateProjectTemplateAsync(
        IProjectTemplateDefinition    projectTemplateDefinition
      , IGenerationContext            generationContext
      , TemplateGenerationOkResult    okResult
      , TemplateGenerationErrorResult errorResult
      , CancellationToken             cancellationToken
    )
    {
        await TryAddFileGenerationAsync(Path.Join(generationContext.Path, $"{projectTemplateDefinition.Name}.csproj")
                                      , projectTemplateDefinition.Name, _ => Task.FromResult(new GeneratedFile
                                                                                             {
                                                                                                 Content
                                                                                                     = projectTemplateDefinition
                                                                                                       .CsProj
                                                                                                       .ToString()
                                                                                               , Path
                                                                                                     = Path
                                                                                                         .Join(generationContext.Path
                                                                                                             , $"{projectTemplateDefinition.Name}.csproj")
                                                                                               , Extension = ".csproj"
                                                                                               , FileName
                                                                                                     = projectTemplateDefinition
                                                                                                         .Name
                                                                                             }), okResult, errorResult
,                                                                                                cancellationToken);

        await TryAddFileGenerationAsync(Path.Join(generationContext.Path, "LICENSE.md")
                                      , Path.Join(generationContext.Path, "LICENSE.md")
                                      , _ => Task.FromResult(new GeneratedFile
                                                             {
                                                                 Content = projectTemplateDefinition.License.ToString()
                                                               , Path = Path.Join(generationContext.Path, "LICENSE.md")
                                                               , Extension = ".md"
                                                               , FileName = "LICENSE.md"
                                                             }), okResult, errorResult, cancellationToken);
        await TryAddFileGenerationAsync(Path.Join(generationContext.Path, "README.md")
                                      , Path.Join(generationContext.Path, "README.md")
                                      , _ => Task.FromResult(new GeneratedFile
                                                             {
                                                                 Content = projectTemplateDefinition.Readme.ToString()
                                                               , Path = Path.Join(generationContext.Path, "README.md")
                                                               , Extension = ".md"
                                                               , FileName = "README.md"
                                                             }), okResult, errorResult, cancellationToken);

        await TryAddFileGenerationAsync(Path.Join(generationContext.Path, ".template.config", "template.json")
                                      , "template.json", _ => Task.FromResult(new GeneratedFile
                                                                              {
                                                                                  Content
                                                                                      = JsonSerializer
                                                                                          .Serialize(new
                                                                                                     ProjectTemplateConfigJson
                                                                                                     {
                                                                                                         Name
                                                                                                             = projectTemplateDefinition
                                                                                                                 .Name
                                                                                                       , Author
                                                                                                             = projectTemplateDefinition
                                                                                                                 .Author
                                                                                                       , Classifications
                                                                                                             = projectTemplateDefinition
                                                                                                               .Classifications
                                                                                                               .ToList()
                                                                                                       , Identity
                                                                                                             = projectTemplateDefinition
                                                                                                                 .Identity
                                                                                                       , ShortName
                                                                                                             = projectTemplateDefinition
                                                                                                                 .ShortName
                                                                                                       , Tags
                                                                                                             = projectTemplateDefinition
                                                                                                                 .Tags
                                                                                                       , Symbols
                                                                                                             = projectTemplateDefinition
                                                                                                               .Symbols
                                                                                                               .Select(x =>
                                                                                                                           new
                                                                                                                           SymbolDefinitionJson
                                                                                                                           {
                                                                                                                               DefaultValue
                                                                                                                                   = x
                                                                                                                                       .DefaultValue
                                                                                                                             , Replaces
                                                                                                                                   = x
                                                                                                                                       .Replaces
                                                                                                                             , Type
                                                                                                                                   = x
                                                                                                                                       .Type
                                                                                                                           })
                                                                                                               .ToList()
                                                                                                     }, new
                                                                                                        JsonSerializerOptions
                                                                                                        {
                                                                                                            WriteIndented
                                                                                                                = true
                                                                                                          , DictionaryKeyPolicy
                                                                                                                = JsonNamingPolicy
                                                                                                                    .CamelCase
                                                                                                        })
                                                                                , Extension = ".json"
                                                                                , FileName  = "template.json"
                                                                                , Path
                                                                                      = Path.Join(generationContext.Path
                                                                                                , ".template.config"
                                                                                                , "template.json")
                                                                              }), okResult, errorResult
,                                                                                 cancellationToken);


        await TryAddFileGenerationAsync(Path.Join(generationContext.Path, ".template.config", "dotnetcli.host.json")
                                      , "dotnetcli.host.json", _ =>
                                                               {
                                                                   return Task.FromResult(new GeneratedFile
                                                                                          {
                                                                                              Content = JsonSerializer
                                                                                                  .Serialize(new
                                                                                                             DotnetCliHostJson
                                                                                                             {
                                                                                                                 SymbolInfo
                                                                                                                     = projectTemplateDefinition
                                                                                                                       .Symbols
                                                                                                                       .Select(x =>
                                                                                                                                   new
                                                                                                                                   TemplateSymbolDefinitionJson
                                                                                                                                   {
                                                                                                                                       ShortName
                                                                                                                                           = x
                                                                                                                                               .ShortName
                                                                                                                                     , LongName
                                                                                                                                           = x
                                                                                                                                               .LongName
                                                                                                                                   })
                                                                                                                       .ToList()
                                                                                                             }, new
                                                                                                                JsonSerializerOptions
                                                                                                                {
                                                                                                                    WriteIndented
                                                                                                                        = true
                                                                                                                  , DictionaryKeyPolicy
                                                                                                                        = JsonNamingPolicy
                                                                                                                            .CamelCase
                                                                                                                })
                                                                                            , Extension = ".json"
                                                                                            , FileName
                                                                                                  = "dotnetcli.host.json"
                                                                                            , Path
                                                                                                  = Path
                                                                                                      .Join(generationContext.Path
                                                                                                          , ".template.config"
                                                                                                          , "dotnetcli.host.json")
                                                                                          });
                                                               }, okResult, errorResult, cancellationToken);
    }

    private async Task TryAddFileGenerationAsync(
        string                                       path
      , string                                       fileName
      , Func<CancellationToken, Task<GeneratedFile>> fileGenerator
      , TemplateGenerationOkResult                   okResult
      , TemplateGenerationErrorResult                errorResult
      , CancellationToken                            cancellationToken = default
    )
    {
        try
        {
            var result = await fileGenerator(cancellationToken);
            okResult.Generation.Add(result);
        }
        catch (Exception ex)
        {
            errorResult.Errors.Add(new GenerationError
                                   {
                                       Path     = path
                                     , FileName = fileName
                                     , Error    = ex.Message
                                   });
        }
    }
}
