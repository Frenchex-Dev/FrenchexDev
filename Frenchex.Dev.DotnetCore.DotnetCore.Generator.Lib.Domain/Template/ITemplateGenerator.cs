#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Template;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Template;

public interface ITemplateGenerator
{
    Task<ITemplateGenerationResult> GenerateAsync(
        ITemplateDefinition templateDefinition
      , ITemplateGenerationContext templateGenerationContext
      , CancellationToken cancellationToken = default
    );
}