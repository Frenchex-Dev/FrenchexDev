#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion


namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public interface IMetaSolutionDefinition
{
    ISolutionDefinition        SolutionDefinition   { get; }
    IList<ITemplateDefinition> TemplatesDefinitions { get; }
    IList<IProjectDefinition>  ProjectsDefinitions  { get; }
}
