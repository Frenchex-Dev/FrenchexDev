﻿#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class ItemSetTemplateDefinition : TemplateDefinition, IItemSetTemplateDefinition
{
    public required IList<IItemTemplateDefinition> Items { get; set; }
}