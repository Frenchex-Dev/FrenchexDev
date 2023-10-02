namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public interface IItemSetTemplateDefinition : ITemplateDefinition
{
    IList<IItemTemplateDefinition> Items { get; }
}