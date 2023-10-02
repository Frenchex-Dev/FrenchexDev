using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

public interface IProjectTemplateGenerator
{
    Task GenerateProjectTemplateAsync(
        IProjectTemplateDefinition projectTemplateDefinition
      , IGenerationContext         generationContext
      , TemplateGenerationResult   result
      , CancellationToken          cancellationToken
    );
}
