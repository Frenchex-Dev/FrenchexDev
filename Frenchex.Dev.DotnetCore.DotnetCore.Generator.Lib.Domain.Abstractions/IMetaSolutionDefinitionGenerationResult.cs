#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public interface IMetaSolutionDefinitionGenerationResult
{
    ISolutionGenerationResult        SolutionGenerationResult    { get; }
    IList<ITemplateGenerationResult> TemplatesGenerationsResults { get; }
    IList<IProjectGenerationResult>  ProjectsGenerationsResults  { get; }
}
