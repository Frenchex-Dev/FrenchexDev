﻿#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.DotnetCore.Project.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Solution.Generator.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Domain.Abstractions;

public interface IMetaSolutionDefinitionGenerationResult
{
    ISolutionGenerationResult        SolutionGenerationResult    { get; }
    IList<ITemplateGenerationResult> TemplatesGenerationsResults { get; }
    IList<IProjectGenerationResult>  ProjectsGenerationsResults  { get; }
}