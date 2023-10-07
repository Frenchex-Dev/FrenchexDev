#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion


using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Template;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public interface IMetaSolutionDefinition
{
    ISolutionDefinition        SolutionDefinition   { get; }
    IList<ITemplateDefinition> TemplatesDefinitions { get; }
    IList<IProjectDefinition>  ProjectsDefinitions  { get; }
}
