#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain;

public interface ITemplateGenerator
{
    Task<ITemplateGenerationResult> GenerateAsync(
        ITemplateDefinition        templateDefinition
      , ITemplateGenerationContext templateGenerationContext
      , CancellationToken          cancellationToken = default
    );
}

public class TemplateGenerator : ITemplateGenerator
{
    public async Task<ITemplateGenerationResult> GenerateAsync(
        ITemplateDefinition        templateDefinition
      , ITemplateGenerationContext templateGenerationContext
      , CancellationToken          cancellationToken = default
    )
    {
        throw new NotImplementedException();
    }
}