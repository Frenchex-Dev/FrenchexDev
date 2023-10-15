#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Project;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Solution;
using Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions.Template;
using Frenchex.Dev.DotnetCore.DotnetCore.Solution.AddProject.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public class MetaSolutionDefinitionGenerationResult : IMetaSolutionDefinitionGenerationResult
{
    public required IList<IAddProjectResult>         AddProjectsToSolutionResults { get; set; }
    public required ISolutionGenerationResult        SolutionGenerationResult     { get; set; }
    public required IList<ITemplateGenerationResult> TemplatesGenerationsResults  { get; set; }
    public required IList<IProjectGenerationResult>  ProjectsGenerationsResults   { get; set; }
}
