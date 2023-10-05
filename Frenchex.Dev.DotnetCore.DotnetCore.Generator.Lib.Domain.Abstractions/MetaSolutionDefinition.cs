using Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public class MetaSolutionDefinition : IMetaSolutionDefinition
{
    public required ISolutionDefinition        SolutionDefinition   { get; set; }
    public required IList<ITemplateDefinition> TemplatesDefinitions { get; set; }
    public required IList<IProjectDefinition>  ProjectsDefinitions  { get; set; }
}