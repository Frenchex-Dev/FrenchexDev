#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

public class TemplateGenerator(
    IProjectTemplateGenerator projectTemplateGenerator
) : ITemplateGenerator
{
    public async Task<ITemplateGenerationResult> GenerateAsync(
        ITemplateDefinition definition
      , IGenerationContext  generationContext
      , CancellationToken   cancellationToken = default
    )
    {
        var result = new TemplateGenerationResult();

        switch (definition)
        {
            case IProjectTemplateDefinition projectTemplateDefinition:
                await projectTemplateGenerator.GenerateProjectTemplateAsync(projectTemplateDefinition, generationContext
                                                                          , result, cancellationToken);
                return result;
            default:
                throw new NotImplementedException(definition.GetType()
                                                            .FullName);
        }
    }
}
