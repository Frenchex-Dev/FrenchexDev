using System.Text.Json;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

public class ProjectTemplateGenerator : IProjectTemplateGenerator
{
    public Task GenerateProjectTemplateAsync(
        IProjectTemplateDefinition projectTemplateDefinition
      , IGenerationContext         generationContext
      , TemplateGenerationResult   result
      , CancellationToken          cancellationToken
    )
    {
        result.Generation.Add(new GeneratedFile
                              {
                                  Content = projectTemplateDefinition.CsProj.ToString()
                                , Path = Path.Join(generationContext.Path, $"{projectTemplateDefinition.Name}.csproj")
                                , Extension = ".csproj"
                                , FileName = projectTemplateDefinition.Name
                              });

        result.Generation.Add(new GeneratedFile
                              {
                                  Content   = projectTemplateDefinition.License.ToString()
                                , Path      = Path.Join(generationContext.Path, "LICENSE.md")
                                , Extension = ".md"
                                , FileName  = "LICENSE.md"
                              });

        result.Generation.Add(new GeneratedFile
                              {
                                  Content   = projectTemplateDefinition.Readme.ToString()
                                , Path      = Path.Join(generationContext.Path, "README.md")
                                , Extension = ".md"
                                , FileName  = "README.md"
                              });

        result.Generation.Add(new GeneratedFile
                              {
                                  Content = JsonSerializer.Serialize(new ProjectTemplateConfigJson
                                                                     {
                                                                         Name   = projectTemplateDefinition.Name
                                                                       , Author = projectTemplateDefinition.Author
                                                                       , Classifications
                                                                             = projectTemplateDefinition.Classifications
                                                                                                        .ToList()
                                                                       , Identity  = projectTemplateDefinition.Identity
                                                                       , ShortName = projectTemplateDefinition.ShortName
                                                                       , Tags = projectTemplateDefinition.Tags
                                                                                                         .ToDictionary()
                                                                       , Symbols = projectTemplateDefinition
                                                                                   .Symbols
                                                                                   .Select(x => new SymbolDefinitionJson
                                                                                                {
                                                                                                    DefaultValue
                                                                                                        = x.DefaultValue
                                                                                                  , Replaces = x
                                                                                                        .Replaces
                                                                                                  , Type = x.Type
                                                                                                })
                                                                                   .ToList()
                                                                     }, new JsonSerializerOptions
                                                                        {
                                                                            WriteIndented = true
                                                                          , DictionaryKeyPolicy
                                                                                = JsonNamingPolicy.SnakeCaseLower
                                                                        })
                                , Extension = ".json"
                                , FileName  = "template.json"
                                , Path      = Path.Join(generationContext.Path, ".template.config", "template.json")
                              });

        result.Generation.Add(new GeneratedFile
                              {
                                  Content = JsonSerializer.Serialize(new DotnetCliHostJson
                                                                     {
                                                                         SymbolInfo = projectTemplateDefinition
                                                                                      .Symbols
                                                                                      .Select(x =>
                                                                                                  new
                                                                                                  TemplateSymbolDefinitionJson
                                                                                                  {
                                                                                                      ShortName = x
                                                                                                          .ShortName
                                                                                                    , LongName = x
                                                                                                          .LongName
                                                                                                  })
                                                                                      .ToList()
                                                                     }, new JsonSerializerOptions
                                                                        {
                                                                            WriteIndented = true
                                                                          , DictionaryKeyPolicy
                                                                                = JsonNamingPolicy.SnakeCaseLower
                                                                        })
                                , Extension = ".json"
                                , FileName = "dotnetcli.host.json"
                                , Path = Path.Join(generationContext.Path, ".template.config", "dotnetcli.host.json")
                              });

        return Task.CompletedTask;
    }
}
