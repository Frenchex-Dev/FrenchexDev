﻿#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Template;

public class TemplateGenerationErrorResult : ITemplateGenerationResult
{
    public required string Error { get; set; }
}