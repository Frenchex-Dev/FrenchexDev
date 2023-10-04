﻿#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain;

public interface ITemplateGenerator
{
    Task<ITemplateGenerationResult> GenerateAsync(
        ITemplateDefinition definition
      , IGenerationContext  generationContext
      , CancellationToken   cancellationToken = default
    );
}
