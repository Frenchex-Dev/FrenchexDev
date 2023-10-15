#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Template;
using IDotnetTemplateGenerator = Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.ITemplateGenerator;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Template;

public class TemplateGenerator(
    IDotnetTemplateGenerator dotnetTemplateGenerator
) : ITemplateGenerator
{
    public Task<ITemplateGenerationResult> GenerateAsync(
        ITemplateDefinition        templateDefinition
      , ITemplateGenerationContext templateGenerationContext
      , CancellationToken          cancellationToken = default
    )
    {
        throw new NotImplementedException();
        /*var dotnetTemplateGenerationResult = await dotnetTemplateGenerator.GenerateAsync(

                                                                                       , new GenerationContext()
                                                                                         {
                                                                                             Path = templateGenerationContext.Path
                                                                                         }
                                                                                       , cancellationToken);*/
    }
}
