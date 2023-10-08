#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Template;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public class MetaSolutionDefinition : IMetaSolutionDefinition
{
    public required ISolutionDefinition        SolutionDefinition   { get; set; }
    public required IList<ITemplateDefinition> TemplatesDefinitions { get; set; }
    public required IList<IProjectDefinition>  ProjectsDefinitions  { get; set; }
}
