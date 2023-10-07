#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public class MetaSolutionDefinitionGenerationResult : IMetaSolutionDefinitionGenerationResult
{
    public required ISolutionGenerationResult        SolutionGenerationResult    { get; set; }
    public required IList<ITemplateGenerationResult> TemplatesGenerationsResults { get; set; }
    public required IList<IProjectGenerationResult>  ProjectsGenerationsResults  { get; set; }
}
